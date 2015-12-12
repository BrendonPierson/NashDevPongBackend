using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPong.Models;

namespace Pong.Tests.Models
{
    [TestClass]
    public class DoublesMatchTests
    {
        [TestMethod]
        public void DoublesMatchEnsureICanInstantiate()
        {
            DoublesMatch match = new DoublesMatch();
            Assert.IsNotNull(match); 
        }

        [TestMethod]
        public void DoublesMatchEnsureMatchContainsAllTheData()
        {
            DateTime now = DateTime.Now;
            DoublesMatch match = new DoublesMatch
            {
                MatchDate = now,
                TeamOne = new DoublesTeam { TeamId = 1 },
                TeamTwo = new DoublesTeam { TeamId = 2 },
                TeamOneScore = 21,
                TeamTwoScore = 12,
                TeamOneElo = 1300,
                TeamTwoElo = 1286
            };
            Assert.AreEqual(now, match.MatchDate);
            Assert.AreEqual(1, match.TeamOne.TeamId);
            Assert.AreEqual(2, match.TeamTwo.TeamId);
            Assert.AreEqual(21, match.TeamOneScore);
            Assert.AreEqual(12, match.TeamTwoScore);
            Assert.AreEqual(1300, match.TeamOneElo);
            Assert.AreEqual(1286, match.TeamTwoElo);
        }
    }
}
