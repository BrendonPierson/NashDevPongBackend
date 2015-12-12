using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPong.Models;

namespace Pong.Tests.Models
{
    [TestClass]
    public class MatchTests
    {
        [TestMethod]
        public void SinglesMatchEnsureICanInstantiate()
        {
            Match match = new Match();
        }

        [TestMethod]
        public void SinglesMatchEnsureAllDataIsStored()
        {
            DateTime now = DateTime.Now;
            Match match = new Match
            {
                PlayerOneElo = 1300,
                PlayerOneId = 1,
                PlayerOneScore = 21,
                PlayerTwoElo = 1299,
                PlayerTwoId = 2,
                PlayerTwoScore = 12,
                MatchDate = now,
                MatchId = 99
            };
            Assert.AreEqual(1300, match.PlayerOneElo);
            Assert.AreEqual(1, match.PlayerOneId);
            Assert.AreEqual(21, match.PlayerOneScore);
            Assert.AreEqual(1299, match.PlayerTwoElo);
            Assert.AreEqual(2, match.PlayerTwoId);
            Assert.AreEqual(12, match.PlayerTwoScore);
            Assert.AreEqual(now, match.MatchDate);
            Assert.AreEqual(99, match.MatchId);
        }
    }
}
