using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Core.Coins;
using VendingMachine.Core.InsertedCoins;
using VendingMachine.Core.Products;

namespace VendingMachine.Core.State
{
    public interface IVendingMachineStateManager
    {
        double CoinInserted(InsertedCoin coin);

        ProductSelectedResponse ProductSelected(Product product);

        IEnumerable<Coin> RefundRequested();
    }
}
