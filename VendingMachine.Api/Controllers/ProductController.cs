using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VendingMachine.Core;

namespace VendingMachine.Api.Controllers
{
    public class ProductController : ApiController
    {
        private static List<Product> _products = new List<Product> {
            new Product(1,"Cola",1.00),
            new Product(1,"Chips",0.50),
            new Product(1,"Candy",0.65),
        };

        public IHttpActionResult Get()
        {
            return Ok(_products);
        }

        public IHttpActionResult Vend(int productId)
        {
            // check total is more than product

            // if not return price and amount in machine

            // if is ok return THANK YOU

            return Ok();
        }
    }
}
