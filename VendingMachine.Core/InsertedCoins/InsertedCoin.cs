namespace VendingMachine.Core.InsertedCoins
{
    public class InsertedCoin
    {
        private InsertedCoin() { }

        public InsertedCoin(double diameter, double thickness, double weight)
        {
            this.Diameter = diameter;
            this.Thickness = thickness;
            this.Weight = weight;
        }
        public double Weight { get; set; }
        public double Thickness { get; set; }
        public double Diameter { get; set; }
    }
}
