using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPong.Models;

namespace Pong.Tests.Models
{
    [TestClass]
    public class DoublesTeamsTests
    {
        [TestMethod]
        public void DoublesTeamsEnsureICanInstantiate()
        {
            DoublesTeam team = new DoublesTeam();
            Assert.IsNotNull(team);
        }

        [TestMethod]
        public void DoublesTeamsEnsureItHasAllProps()
        {
            DoublesTeam team = new DoublesTeam
            {
                TeamId = 1,
                PlayerTwo = new Player { PlayerId = 2 },
                PlayerOne = new Player { PlayerId = 3 },
                TeamName = "Blue Baracudas",
                EloRating = 1300
            };
            Assert.AreEqual(1, team.TeamId);
            Assert.AreEqual(2, team.PlayerTwo.PlayerId);
            Assert.AreEqual(3, team.PlayerOne.PlayerId);
            Assert.AreEqual("Blue Baracudas", team.TeamName);
            Assert.AreEqual(1300, team.EloRating);
        }
    }
}
