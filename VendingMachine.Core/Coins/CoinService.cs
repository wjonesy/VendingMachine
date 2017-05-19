using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Core.Coins
{
    public class CoinService : ICoinService
    {
        private readonly List<Coin> _coins;
        private readonly List<InsertedCoin> _availableCoins;
        private readonly List<Tuple<double, double, double, double>> _coinDimensionsToCoinValueMap;


        public CoinService()
        {
            if (_coins == null)
            {
                _coins = new List<Coin>(); _coins.Add(new Coin { Value = 0.01 });
                _coins.Add(new Coin { Value = 0.02 });
                _coins.Add(new Coin { Value = 0.05 });
                _coins.Add(new Coin { Value = 0.10 });
            }
            if (_availableCoins == null)
            {
                _availableCoins = new List<InsertedCoin>();
                _availableCoins.Add(new InsertedCoin(19.05, 1.55, 2.5));
                _availableCoins.Add(new InsertedCoin(21.20, 1.95, 5));
                _availableCoins.Add(new InsertedCoin(17.9, 1.35, 2.27));
                _availableCoins.Add(new InsertedCoin(24.26, 1.75, 5.67));
            }

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
