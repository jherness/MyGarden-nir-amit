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
    public class ActivationHistoryController : ApiController
    {
        [HttpGet]
        public Task<List<ActivationHistory>> GetActivationHistory()
        {
            return BuisnessLL.GetActHistCollection();
        }
    }
}