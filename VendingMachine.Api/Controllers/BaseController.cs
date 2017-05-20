using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace VendingMachine.Api.Controllers
{
    [EnableCors("http://localhost:57440", headers: "*", methods: "*")]
    public class BaseController : ApiController
    {
    }
}
