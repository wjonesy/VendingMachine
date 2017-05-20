using System.Collections.Generic;
using VendingMachine.Core.Coins;

namespace VendingMachine.Core.State
{
    public class ProductSelectedResponse
    {
        private ProductSelectedResponse() { }

        public ProductSelectedResponse(double amountToPay)
        {
            this.AmountToPay = amountToPay;
            this.ReturnedCoins = null;
        }

        public ProductSelectedResponse(IEnumerable<Coin> returnedCoins)
        {
            this.ReturnedCoins = returnedCoins;
            this.AmountToPay = null;
        }

        public double? AmountToPay { get; private set; }

        public IEnumerable<Coin> ReturnedCoins { get; private set; }
    }
}
