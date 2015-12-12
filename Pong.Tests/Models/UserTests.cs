using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PingPong.Models;

namespace Pong.Tests.Models
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void UserEnsureIcanInstantiate()
        {
            User user = new User();
            Assert.IsNotNull(user);
        }

        [TestMethod]
        public void UserEnsureUserHasAllTheProperties()
        {
            User user = new User
            {
                FirstName = "brendon",
                LastName = "pierson",
                Handle = "bierson",
                EloRating = 1300,
                UserId = 1
            };
            Assert.AreEqual("brendon", user.FirstName);
            Assert.AreEqual("pierson", user.LastName);
            Assert.AreEqual("bierson", user.Handle);
            Assert.AreEqual(1300, user.EloRating);
            Assert.AreEqual(1, user.UserId);
        }

        [TestMethod]
        public void UserEnsureHasDefaultId()
        {
            User user = new User();
            Assert.IsNotNull(user.UserId);
        }
    }
}
