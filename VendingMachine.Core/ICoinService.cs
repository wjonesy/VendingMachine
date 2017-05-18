using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Core
{
    public interface ICoinService
    {
        double? GetCoinValue(InsertedCoin insertedCoin);
    }
}
