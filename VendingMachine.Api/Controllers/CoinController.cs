using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VendingMachine.Core;
using VendingMachine.Core.Coins;
using VendingMachine.Core.InsertedCoins;

namespace VendingMachine.Api.Controllers
{
    public class CoinController : ApiController
    {
        private ICoinService _coinService { get; set; }

        public CoinController(ICoinService coinService)
        {
            _coinService = coinService;
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
            var value = _coinService.GetCoinValue(coin);
            return Ok(value);
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Refund()
        {
            // return the inserted coins
            return Ok();
        }
    }
}
