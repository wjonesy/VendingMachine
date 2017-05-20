using System.Web.Http;
using VendingMachine.Core.Products;
using VendingMachine.Core.State;

namespace VendingMachine.Api.Controllers
{
    public class ProductController : ApiController
    {
        private IProductService _productService;
        private IVendingMachineStateManager _vendingMachineStateManager;

        public ProductController(IProductService productService, IVendingMachineStateManager vendingMachineStateManager)
        {
            _productService = productService;
            _vendingMachineStateManager = vendingMachineStateManager;
        }

        public IHttpActionResult Get()
        {
            return Ok(_productService.GetAll());
        }

        public IHttpActionResult Vend(int productId)
        {
            return Ok(_vendingMachineStateManager.ProductSelected(productId));
        }
    }
}
