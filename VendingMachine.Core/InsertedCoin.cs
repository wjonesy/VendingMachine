using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Core
{
    public class InsertedCoin
    {
        public InsertedCoin(double diameter, double thickness, double weight)
        {
            Diameter = diameter;
            Thickness = thickness;
            Weight = weight;
        }
        public double Weight { get; set; }
        public double Thickness { get; set; }
        public double Diameter { get; set; }
    }
}
