using System.Collections.Generic;
using VendingMachine.Core.Coins;

namespace VendingMachine.Core.State
{
    public class ProductSelectedResponse
    {
        private ProductSelectedResponse() { }

        public ProductSelectedResponse(int productPrice)
        {
            this.ProductPrice = productPrice;
            this.ReturnedCoins = null;
        }

        public ProductSelectedResponse(IEnumerable<Coin> returnedCoins)
        {
            this.ReturnedCoins = returnedCoins;
            this.ProductPrice = null;
        }

        public int? ProductPrice { get; private set; }

        public IEnumerable<Coin> ReturnedCoins { get; private set; }
    }
}
