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
            Player[] players = new Player[2];
            players[0] = new Player { PlayerId = 2 };
            players[1] = new Player { PlayerId = 3 };
            DoublesTeam team = new DoublesTeam
            {
                TeamId = 1,
                TeamMembers = players,
                TeamName = "Blue Baracudas",
                EloRating = 1300
            };
            Assert.AreEqual(1, team.TeamId);
            Assert.AreEqual(2, team.TeamMembers[0].PlayerId);
            Assert.AreEqual(3, team.TeamMembers[1].PlayerId);
            Assert.AreEqual("Blue Baracudas", team.TeamName);
            Assert.AreEqual(1300, team.EloRating);
        }
    }
}
