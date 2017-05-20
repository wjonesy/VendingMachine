using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Core.Products
{
    public class ProductService : IProductService
    {
        private readonly IEnumerable<Product> _products;
        public ProductService()
        {
            _products = new Product[] {
                ProductConstants.Cola,
                ProductConstants.Candy,
                ProductConstants.Chips
            };
        }


        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
    }
}
