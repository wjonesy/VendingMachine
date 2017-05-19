namespace VendingMachine.Core.InsertedCoins
{
    public static class InsertedCoinsConstants
    { 
        public static readonly InsertedCoin Penny = new InsertedCoin(19.05, 1.55, 2.5);
        public static readonly InsertedCoin Nickel = new InsertedCoin(21.20, 1.95, 5);
        public static readonly InsertedCoin Dime = new InsertedCoin(17.9, 1.35, 2.27);
        public static readonly InsertedCoin Quarter = new InsertedCoin(24.26, 1.75, 5.67);
    }
}
