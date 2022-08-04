using Database.Classes;
using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using MoreLinq.Extensions;

namespace MyGarden.Controllers
{

    public class ExceptionsCountersController : ApiController
    {
        [HttpGet]
        public Task<List<ExceptionCounter>> GetExceptionsCounters()
        {
            return BuisnessLL.GetExceptionsCountersCollection();
        }

        [HttpGet]
        [Route("api/GetMostCommenException")]
        public Task<ExceptionCounter> GetMostCommenException()
        {
            return BuisnessLL.GetMostCommenException();
        }


    }
}