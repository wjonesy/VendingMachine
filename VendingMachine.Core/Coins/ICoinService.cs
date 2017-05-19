using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Core.InsertedCoins;

namespace VendingMachine.Core.Coins
{
    public interface ICoinService
    {
        double? GetCoinValue(InsertedCoin insertedCoin);
    }
}
