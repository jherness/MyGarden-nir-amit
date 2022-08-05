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
    }
}