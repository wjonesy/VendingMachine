using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VendingMachine.Core;

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
            if (coin == null)
            {
                return BadRequest();
            }
            var value = _coinService.GetCoinValue(coin);
            return Ok(value);
        }
    }
}
