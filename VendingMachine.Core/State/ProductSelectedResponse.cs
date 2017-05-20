using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Core.Coins;

namespace VendingMachine.Core.State
{
    public class ProductSelectedResponse
    {
        private ProductSelectedResponse() { }

        public ProductSelectedResponse(double amountToPay)
        {
            this.AmountToPay = amountToPay;
            this.Refund = null;
        }

        public ProductSelectedResponse(IEnumerable<Coin> refundedCoins)
        {
            this.Refund = refundedCoins;
            this.AmountToPay = null;
        }

        double? AmountToPay { get; set; }

        IEnumerable<Coin> Refund { get; set; }
    }
}
