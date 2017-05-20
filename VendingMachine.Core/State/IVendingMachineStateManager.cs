using System.Collections.Generic;
using VendingMachine.Core.Coins;
using VendingMachine.Core.InsertedCoins;

namespace VendingMachine.Core.State
{
    public interface IVendingMachineStateManager
    {
        VendingMachineState GetCurrentState();

        int CoinInserted(InsertedCoin coin);

        ProductSelectedResponse ProductSelected(int productId);

        List<Coin> RefundRequested();
    }
}
