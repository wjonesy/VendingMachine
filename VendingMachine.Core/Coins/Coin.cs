namespace VendingMachine.Core.Coins
{
    public class Coin
    {
        private Coin() { }

        public Coin(double value)
        {
            this.Value = value;
        }
        public double Value { get; set; }
    }
}
