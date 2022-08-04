using Database;
using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MyGarden.Controllers
{
    [RoutePrefix("api/{controller}")]
    public class HandleExceptionsController : ApiController
    {
        [HttpGet]
        public Task<List<HandleException>> GetHandleExceptions()
        {
            return BuisnessLL.GetHandleExceptionCollection();
        }
    }
}