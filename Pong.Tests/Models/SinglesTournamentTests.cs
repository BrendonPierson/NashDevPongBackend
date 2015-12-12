using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPong.Models;
using System.Collections.Generic;

namespace Pong.Tests.Models
{
    [TestClass]
    public class SinglesTournamentTests
    {
        [TestMethod]
        public void SinglesTournamentEnsureICanInstantiate()
        {
            SinglesTournament tourney = new SinglesTournament();
            Assert.IsNotNull(tourney);
        }

        [TestMethod]
        public void SinglesTournamentEnsureHasAllTheData()
        {
            DateTime now = DateTime.Now;
            SinglesTournament tourney = new SinglesTournament
            {
                TournamentId = 1,
                TournamentName = "NashDevWeekly",
                StartDate = now,
                Players = new List<Player>
                {
                    new Player { PlayerId = 1 },
                    new Player { PlayerId = 2 }
                },
                SinglesMatches = new List<SinglesMatch>
                {
                    new SinglesMatch { MatchId = 3 },
                    new SinglesMatch { MatchId = 4 },
                },
                IsActive = true
            };
            Assert.AreEqual(1, tourney.TournamentId);
            Assert.AreEqual("NashDevWeekly", tourney.TournamentName);
            Assert.AreEqual(now, tourney.StartDate);
            Assert.AreEqual(2, tourney.Players[1].PlayerId);
            Assert.AreEqual(3, tourney.SinglesMatches[0].MatchId);
            Assert.AreEqual(true, tourney.IsActive);
        }
    }
}
