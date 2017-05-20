using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachine.Core.InsertedCoins;

namespace VendingMachine.Core.Coins
{
    public class CoinService : ICoinService
    {
        private readonly List<Coin> _coins;
        private readonly List<InsertedCoin> _availableCoins;
        private readonly List<Tuple<double, double, double, int>> _coinDimensionsToCoinValueMap;


        public CoinService()
        {
            _coins = new List<Coin>() {
                CoinConstants.Penny,
                CoinConstants.Nickel,
                CoinConstants.Dime,
                CoinConstants.Quarter
            };

            _availableCoins = new List<InsertedCoin>() {
                InsertedCoinsConstants.Penny,
                InsertedCoinsConstants.Nickel,
                InsertedCoinsConstants.Dime,
                InsertedCoinsConstants.Quarter
            };

            if (_coinDimensionsToCoinValueMap == null)
            {
                _coinDimensionsToCoinValueMap = new List<Tuple<double, double, double, int>>();

                for (int i = 0; i < _coins.Count; i++)
                {
                    _coinDimensionsToCoinValueMap.Add(new Tuple<double, double, double, int>(
                        _availableCoins.Skip(i).Take(1).Single().Diameter,
                        _availableCoins.Skip(i).Take(1).Single().Thickness,
                        _availableCoins.Skip(i).Take(1).Single().Weight,
                       _coins.Skip(i).Take(1).Single().Value));
                }
            }
        }

        public Coin GetCoin(InsertedCoin insertedCoin)
        {
            var coinValue = GetCoinValue(insertedCoin);
            if (coinValue == null)
            {
                return null;
            }
            return _coins.Where(x => x.Value == coinValue)
                .FirstOrDefault();
        }

        public List<Coin> GetCoinsForAmount(int amount)
        {
            var coins = _coins.OrderByDescending(x => x.Value);

            var coinsToReturn = new List<Coin>();

            var amountLeft = amount;
            while (amountLeft > 0)
            {
                foreach (var coin in coins)
                {
                    var multiple = amountLeft / coin.Value;
                    if (multiple > 0)
                    {
                        for (int i = 0; i < multiple; i++)
                        {
                            coinsToReturn.Add(coin);
                        }

                        amountLeft = amountLeft - (multiple * coin.Value);
                    }
                }
            }

            return coinsToReturn;

        }

        public int GetCoinsTotalValue(IEnumerable<InsertedCoin> insertedCoins)
        {
            var total = 0;
            foreach (var coin in insertedCoins)
            {
                var value = GetCoinValue(coin);
                if (value == null)
                {
                    throw new Exception("The inserted coin is not valid.");
                }
                total += value.Value;
            }
            return total;
        }

        public int? GetCoinValue(InsertedCoin insertedCoin)
        {
            return _coinDimensionsToCoinValueMap
                .Where(x => x.Item1 == insertedCoin.Diameter)
                .Where(x => x.Item2 == insertedCoin.Thickness)
                .Where(x => x.Item3 == insertedCoin.Weight)
                .FirstOrDefault()?.Item4;
        }
    }
}
