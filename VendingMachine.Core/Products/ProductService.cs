﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace VendingMachine.Core.Products
{
    public class ProductService : IProductService
    {
        private static readonly IEnumerable<Product> _products = new Product[] {
                ProductConstants.Cola,
                ProductConstants.Candy,
                ProductConstants.Chips
    };
        public ProductService()
        {

        }

        public Product Get(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            return _products.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
    }
}
