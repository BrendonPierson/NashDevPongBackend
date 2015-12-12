using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPong.Models;
using System.Collections.Generic;

namespace Pong.Tests.Models
{
    [TestClass]
    public class DoublesTournamentTests
    {
        [TestMethod]
        public void DoublesTournamentEnsureICanInstantiate()
        {
            DoublesTournament tourney = new DoublesTournament();
            Assert.IsNotNull(tourney);
        }

        [TestMethod]
        public void DoublesTournamentEnsureHasAllTheData()
        {
            DateTime now = DateTime.Now;
            DoublesTournament tourney = new DoublesTournament
            {
                TournamentId = 1,
                TournamentName = "NashDevWeekly",
                StartDate = now,
                Teams = new List<DoublesTeam>
                {
                    new DoublesTeam { TeamId = 1 },
                    new DoublesTeam { TeamId = 2 }
                },
                DoublesMatches = new List<DoublesMatch>
                {
                    new DoublesMatch { MatchId = 3 },
                    new DoublesMatch { MatchId = 4 },
                },
                IsActive = true
            };
            Assert.AreEqual(1, tourney.TournamentId);
            Assert.AreEqual("NashDevWeekly", tourney.TournamentName);
            Assert.AreEqual(now, tourney.StartDate);
            Assert.AreEqual(2, tourney.Teams[1].TeamId);
            Assert.AreEqual(3, tourney.DoublesMatches[0].MatchId);
            Assert.AreEqual(true, tourney.IsActive);
        }
    }
}
