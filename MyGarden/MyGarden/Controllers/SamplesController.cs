using Server;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MongoDB.Driver;
using System.Threading.Tasks;
using Database.Classes;
using System.Net;

namespace MyGarden.Controllers
{
    [RoutePrefix("api/Samples")]
    public class SamplesController : ApiController
    {
        [HttpGet]
        public Task<List<Sample>> GetSamples() {
            return BuisnessLL.GetSamplesCollection();
        }

        [HttpGet]
        [Route("api/GetLatestSample")]
        public Task<Sample> GetLatestSamples()
        {
            return BuisnessLL.GetLatestSample();
        }

        [Route("InsertNewSample")]
        [HttpPost]// for loader to send data to server
        public IHttpActionResult InsertNewSample([FromBody] Sample newSample)
        {
            try
            {
                var samp = BuisnessLL.InsertNewSample(newSample);
                if(samp != null)
                    return Ok(newSample);
                return Content(HttpStatusCode.NotFound, "ERROR, Terminated process");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}