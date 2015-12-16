using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PingPong.Controllers
{
    public class SinglesMatchesController : ApiController
    {
        // GET: api/PingPongApi
        public string Get()
        {
            return "this is the title from the api";
        }

        // GET: api/PingPongApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PingPongApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PingPongApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PingPongApi/5
        public void Delete(int id)
        {
        }
    }
}
