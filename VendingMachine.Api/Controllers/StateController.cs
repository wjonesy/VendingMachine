using System.Web.Http;
using VendingMachine.Core.State;

namespace VendingMachine.Api.Controllers
{
    public class StateController : BaseController
    {
        private readonly IVendingMachineStateManager _vendingMachineStateManager;

        public StateController(IVendingMachineStateManager vendingMachineStateManager)
        {
            _vendingMachineStateManager = vendingMachineStateManager;
        }

        [HttpGet]
        public IHttpActionResult Current()
        {
            return Ok(_vendingMachineStateManager.GetCurrentState());
        }
    }
}
