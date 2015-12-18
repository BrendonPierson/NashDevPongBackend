using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using PingPong.Models;

namespace PingPong.Controllers
{
    public class SinglesMatchesController : ApiController
    {
        public PingPongRepository Repo { get; set; }
        SinglesMatchesController()
        {
            Repo = new PingPongRepository();
        }

        // GET: api/PingPongApi
        public List<SinglesMatch> Get()
        {
            List<SinglesMatch> sMatches = Repo.GetAllSinglesMatches();
            return sMatches;
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
