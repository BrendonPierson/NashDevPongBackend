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
                PlayerTwoId = 2,
                PlayerOneId = 3,
                TeamName = "Blue Baracudas",
                EloRating = 1300
            };
            Assert.AreEqual(1, team.TeamId);
            Assert.AreEqual(2, team.PlayerTwoId);
            Assert.AreEqual(3, team.PlayerOneId);
            Assert.AreEqual("Blue Baracudas", team.TeamName);
            Assert.AreEqual(1300, team.EloRating);
        }
    }
}
