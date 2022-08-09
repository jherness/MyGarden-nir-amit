using Database;
using Database.Classes;
using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MyGarden.Controllers
{

    public class AvgSamplesController : ApiController
    {
        [HttpGet]
        public Task<List<AvgSample>> GetAvgSamples()
        {
            return BuisnessLL.GetAvgSamplesCollection();
        }

        [HttpGet]
        [Route("api/GetLatestAvgSample")]
        public Task<AvgSample> GetLatestAvgSample()
        {
            return BuisnessLL.GetLatestAvgSample();
        }

        [HttpGet]
        [Route("api/GetRaining")]
        public List<AvgSample> GetRaining()
        {
            return BuisnessLL.GetRaining();
        }

        [HttpPost]
        [Route("api/ActivateRelay")]//sends data to relays
        public IHttpActionResult ActivateRelay([FromBody] Relays rls)
        {
            try
            {
                var samp = BuisnessLL.ActivateRelay(rls);
                if (samp != null)
                    return Ok(rls);
                return Content(HttpStatusCode.NotFound, "ERROR, Terminated process");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}