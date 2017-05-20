using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Core.Coins;
using VendingMachine.Core.InsertedCoins;
using VendingMachine.Core.Products;

namespace VendingMachine.Core.State
{
    public class VendingMachineStateManager : IVendingMachineStateManager
    {
        private const string _cacheName = "VendingMachine";
        private static MemoryCache _cache = new MemoryCache(_cacheName);


        private readonly ICoinService _coinService;

        public VendingMachineStateManager(ICoinService coinService)
        {
            _coinService = coinService;
        }

        public double CoinInserted(InsertedCoin coin)
        {
            // add the coin to the machine
            var coinsInMachine = _cache.Get("coins_in_machine") as List<InsertedCoin>;
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

        public ProductSelectedResponse ProductSelected(Product product)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Coin> RefundRequested()
        {
            throw new NotImplementedException();
        }
    }
}
