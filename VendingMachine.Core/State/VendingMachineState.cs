using System.Collections.Generic;
using VendingMachine.Core.Products;

namespace VendingMachine.Core.State
{
    public class VendingMachineState
    {
        public IEnumerable<Product> Products { get; set; }
        public int ValueOfCoinsInMachine { get; set; }
    }
}
