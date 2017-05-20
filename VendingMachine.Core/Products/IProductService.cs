using System.Collections.Generic;

namespace VendingMachine.Core.Products
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product Get(int id);
    }
}
