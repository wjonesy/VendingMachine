namespace VendingMachine.Core.Coins
{
    public class Coin
    {
        private Coin() { }

        public Coin(int value)
        {
            this.Value = value;
        }
        public int Value { get; set; }
    }
}
