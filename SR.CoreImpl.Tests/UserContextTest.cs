using System;
using NUnit.Framework;
using SR.Core.Context;
using SR.Tiskarna;

namespace SR.CoreImpl.Tests
{

    [TestFixture]
    public class UserContextTest
    {
        [Test]
        public void CreateContext()
        {
            TiskarnaVosahlo.Autentication.LogIn(MASTER_USERNAME, MASTER_PASSWORD);

            Assert.AreEqual(MASTER_USERNAME, UserContext.User.Username);
            Assert.AreEqual(MASTER_PASSWORD, UserContext.User.Password);

            UserContext.Logout();
        }

        [Test]
        public void CloseContext()
        {
            TiskarnaVosahlo.Autentication.LogIn(MASTER_USERNAME, MASTER_PASSWORD);

            UserContext.Logout();

            Assert.AreEqual(null, UserContext.User);
        }


        #region Tests Initialization

        [SetUp]
        public void TestInit()
        {
            new TiskarnaVosahlo();
        }

        [TearDown]
        public void TestCleanup()
        {
        }

        [OneTimeSetUpAttribute]
        public void AllTestsInit()
        {
        }

        [OneTimeTearDownAttribute]
        public void AllTestCleanup()
        {
        }

        #endregion

        private const String MASTER_USERNAME = "UberNjorloj";
        private const String MASTER_PASSWORD = "IddqdIdkfa";

        private const String GUEST_USERNAME = "Guest";
        private const String GUEST_PASSWORD = "guest";
    }
}
