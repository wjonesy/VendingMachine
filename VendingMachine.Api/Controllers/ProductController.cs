using System.Web.Http;
using VendingMachine.Core.Products;
using VendingMachine.Core.State;

namespace VendingMachine.Api.Controllers
{
    public class ProductController : BaseController
    {
        private IProductService _productService;
        private IVendingMachineStateManager _vendingMachineStateManager;

        public ProductController(IProductService productService, IVendingMachineStateManager vendingMachineStateManager)
        {
            _productService = productService;
            _vendingMachineStateManager = vendingMachineStateManager;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet]
        public IHttpActionResult Vend([FromUri]int id)
        {
            return Ok(_vendingMachineStateManager.ProductSelected(id));
        }
    }
}
