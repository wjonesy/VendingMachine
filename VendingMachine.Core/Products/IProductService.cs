using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Core.Products
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
    }
}
