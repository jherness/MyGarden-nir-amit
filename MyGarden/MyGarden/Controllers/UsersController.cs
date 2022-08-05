using Database.Classes;
using MongoDB.Driver;
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
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("IsUserRegistered")]
        public IHttpActionResult IsUserRegistered([FromBody]User user)
        {
            try
            {
                bool isRegistered = BuisnessLL.IsRegistered(user);
                if (isRegistered)
                {
                    return Ok(isRegistered);
                }
                return Content(HttpStatusCode.NotFound, false);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateUserPassword")]
        public IHttpActionResult UpdateUserPassword([FromBody] User userToUpdate, string newPassword)
        {
            try
            {
                User res = BuisnessLL.UpdateUserPass(userToUpdate, newPassword);
                if (res != null)
                {
                    return Ok(res);
                }
                return Content(HttpStatusCode.NotFound, "user not found");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}