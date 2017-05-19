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
        private readonly List<Tuple<double, double, double, double>> _coinDimensionsToCoinValueMap;


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
                _coinDimensionsToCoinValueMap = new List<Tuple<double, double, double, double>>();

                for (int i = 0; i < _coins.Count; i++)
                {
                    _coinDimensionsToCoinValueMap.Add(new Tuple<double, double, double, double>(
                        _availableCoins.Skip(i).Take(1).Single().Diameter,
                        _availableCoins.Skip(i).Take(1).Single().Thickness,
                        _availableCoins.Skip(i).Take(1).Single().Weight,
                       _coins.Skip(i).Take(1).Single().Value));
                }
            }
        }

        public double? GetCoinValue(InsertedCoin insertedCoin)
        {
            return _coinDimensionsToCoinValueMap
                .Where(x => x.Item1 == insertedCoin.Diameter)
                .Where(x => x.Item2 == insertedCoin.Thickness)
                .Where(x => x.Item3 == insertedCoin.Weight)
                .FirstOrDefault()?.Item4;
        }
    }
}
