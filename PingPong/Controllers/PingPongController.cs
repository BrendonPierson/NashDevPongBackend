using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PingPong.Models;

namespace PingPong.Controllers
{
    public class PingPongController : Controller
    {
        public PingPongRepository Repo { get; set; }

        public PingPongController() : base()
        {
            Repo = new PingPongRepository();
        }

        // GET: PingPong
        // Maybe the Public feed here?
        public ActionResult Index()
        {
            List<SinglesMatch> sMatches = Repo.GetAllSinglesMatches();

            return View(sMatches);
        }

        [Authorize]
        public ActionResult TopFavs()
        {
            return View();
        }
    }
}