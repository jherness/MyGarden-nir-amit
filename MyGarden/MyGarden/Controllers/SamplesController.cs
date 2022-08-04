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

namespace MyGarden.Controllers
{
    [RoutePrefix("api/{controller}")]
    public class SamplesController : ApiController
    {
        [HttpGet]
        public Task<List<Sample>> GetSamples() {
            return BuisnessLL.GetSamplesCollection();
        }
    }
}