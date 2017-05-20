using System.Collections.Generic;
using VendingMachine.Core.InsertedCoins;

namespace VendingMachine.Core.Coins
{
    public interface ICoinService
    {
        Coin GetCoin(InsertedCoin insertedCoin);

        int? GetCoinValue(InsertedCoin insertedCoin);

        int GetCoinsTotalValue(IEnumerable<InsertedCoin> insertedCoins);

        List<Coin> GetCoinsForAmount(int amount);
    }
}
