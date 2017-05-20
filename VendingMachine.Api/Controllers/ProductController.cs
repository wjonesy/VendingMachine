using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VendingMachine.Core;
using VendingMachine.Core.Products;

namespace VendingMachine.Api.Controllers
{
    public class ProductController : ApiController
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IHttpActionResult Get()
        {
            return Ok(_productService.GetAll());
        }

        public IHttpActionResult Vend(int productId)
        {
            // check total coin value in machine is more than product

            // if not return price and amount in machine

            // if is ok return THANK YOU and remove the coins from the machine's cache

            return Ok();
        }
    }
}
