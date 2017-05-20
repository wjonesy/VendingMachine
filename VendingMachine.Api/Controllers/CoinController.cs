using System.Web.Http;
using VendingMachine.Core.InsertedCoins;
using VendingMachine.Core.State;

namespace VendingMachine.Api.Controllers
{
    public class CoinController : ApiController
    {
        private IVendingMachineStateManager _vendingMachineStateManager;

        public CoinController(IVendingMachineStateManager vendingMachineStateManager)
        {
            _vendingMachineStateManager = vendingMachineStateManager;
        }

        [HttpPost]
        public IHttpActionResult Insert(InsertedCoin coin)
        {
            // save the new coin in the machine
            // return the value of the amount of coins in the machine
            if (coin == null)
            {
                return BadRequest();
            }

            return Ok(_vendingMachineStateManager.CoinInserted(coin));
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Refund()
        {
            // return the inserted coins
            return Ok(_vendingMachineStateManager.RefundRequested());
        }
    }
}
