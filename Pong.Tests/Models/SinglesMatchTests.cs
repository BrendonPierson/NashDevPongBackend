using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPong.Models;

namespace Pong.Tests.Models
{
    [TestClass]
    public class SinglesMatchTests
    {
        [TestMethod]
        public void SinglesMatchEnsureICanInstantiate()
        {
            SinglesMatch match = new SinglesMatch();
        }

        [TestMethod]
        public void SinglesMatchEnsureAllDataIsStored()
        {
            DateTime now = DateTime.Now;
            SinglesMatch match = new SinglesMatch
            {
                PlayerOneElo = 1300,
                PlayerOne = new Player { PlayerId = 1 },
                PlayerOneScore = 21,
                PlayerTwoElo = 1299,
                PlayerTwo = new Player { PlayerId = 2 },
                PlayerTwoScore = 12,
                MatchDate = now,
                MatchId = 99
            };
            Assert.AreEqual(1300, match.PlayerOneElo);
            Assert.AreEqual(1, match.PlayerOne.PlayerId);
            Assert.AreEqual(21, match.PlayerOneScore);
            Assert.AreEqual(1299, match.PlayerTwoElo);
            Assert.AreEqual(2, match.PlayerTwo.PlayerId);
            Assert.AreEqual(12, match.PlayerTwoScore);
            Assert.AreEqual(now, match.MatchDate);
            Assert.AreEqual(99, match.MatchId);
        }
    }
}
