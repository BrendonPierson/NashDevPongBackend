using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPong.Models;

namespace Pong.Tests.Models
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void PlayerEnsureIcanInstantiate()
        {
            Player player = new Player();
            Assert.IsNotNull(player);
        }

        [TestMethod]
        public void PlayerEnsurePlayerHasAllTheProperties()
        {
            Player player = new Player
            {
                FirstName = "brendon",
                LastName = "pierson",
                Handle = "bierson",
                EloRating = 1300,
                PlayerId = 1
            };
            Assert.AreEqual("brendon", player.FirstName);
            Assert.AreEqual("pierson", player.LastName);
            Assert.AreEqual("bierson", player.Handle);
            Assert.AreEqual(1300, player.EloRating);
            Assert.AreEqual(1, player.PlayerId);
        }

        [TestMethod]
        public void PlayerEnsureHasDefaultId()
        {
            Player player = new Player();
            Assert.IsNotNull(player.PlayerId);
        }
    }
}
