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
            Player p1 = new Player { Handle = "pongBaller", EloRating = 1300 };
            Player p2 = new Player { Handle = "spinDoctor", EloRating = 1200 };

            List<SinglesMatch> sMatches = new List<SinglesMatch>
            {
                new SinglesMatch
                {
                    PlayerOne = p1,
                    PlayerOneElo = 1300,
                    PlayerOneScore = 21,
                    PlayerTwo = p2,
                    PlayerTwoElo = 1200,
                    PlayerTwoScore = 12
                }
            };
            //Repo.AddSinglesMatch(p1, p2, 21, 15);
            //List<SinglesMatch> sMatches = Repo.GetAllSinglesMatches();
            
            return View(sMatches);
        }

        [Authorize]
        public ActionResult TopFavs()
        {
            return View();
        }
    }
}