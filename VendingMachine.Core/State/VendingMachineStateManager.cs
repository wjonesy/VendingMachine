using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using VendingMachine.Core.Coins;
using VendingMachine.Core.InsertedCoins;
using VendingMachine.Core.Products;

namespace VendingMachine.Core.State
{
    public class VendingMachineStateManager : IVendingMachineStateManager
    {
        private const string _cacheName = "VendingMachine";
        private const string _cache_coinsInMachine = "coins_in_machine";
        private static MemoryCache _cache = new MemoryCache(_cacheName);


        private readonly ICoinService _coinService;
        private readonly IProductService _productService;

        public VendingMachineStateManager(ICoinService coinService, IProductService productService)
        {
            _coinService = coinService;
            _productService = productService;
        }

        public double CoinInserted(InsertedCoin coin)
        {
            // add the coin to the machine
            var coinsInMachine = GetCoinsInMachine();
            if (coinsInMachine == null)
            {
                coinsInMachine = new List<InsertedCoin>();
            }

            // make sure coin is valid
            var coinValue = _coinService.GetCoinValue(coin);
            if (coinValue == null)
            {
                throw new Exception("The inserted coin is not valid.");
            }

            // add the coin to the machine
            coinsInMachine.Add(coin);
            _cache.Add(new CacheItem("coins_in_machine", coinsInMachine), new CacheItemPolicy());


            // return the new value of all the coins in the machine
            return _coinService.GetCoinsTotalValue(coinsInMachine);
        }

        public ProductSelectedResponse ProductSelected(int productId)
        {
            // check the product exists
            var product = _productService.Get(productId);
            if (product == null)
            {
                throw new Exception($"The product with id {productId} does not exist.");
            }

            var coinsInMachine = GetCoinsInMachine();
            var totalValueInMachine = _coinService.GetCoinsTotalValue(coinsInMachine);

            if (totalValueInMachine < product.Price)
            {
                return new ProductSelectedResponse(product.Price - totalValueInMachine);
            }
            else
            {

                return new ProductSelectedResponse(_coinService.GetCoinsForAmount(totalValueInMachine - product.Price));
            }
        }

        public List<Coin> RefundRequested()
        {
            // get the coins in the machine
            var coinsInMachine = GetCoinsInMachine();

            if (coinsInMachine == null)
            {
                return null;
            }
            // get the coins to return in the refund
            var refund = new List<Coin>();
            foreach (var insertedCoin in coinsInMachine)
            {
                var coin = _coinService.GetCoin(insertedCoin);
                if (coin != null)
                {
                    refund.Add(coin);
                }
            }

            // now we have all the coins, delete the cache
            _cache.Remove(_cache_coinsInMachine);

            return refund;
        }

        private List<InsertedCoin> GetCoinsInMachine()
        {
            return _cache.Get(_cache_coinsInMachine) as List<InsertedCoin>;
        }
    }
}
