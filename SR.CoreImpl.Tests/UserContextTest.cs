using NUnit.Framework;

using SR.Core.Context;
using SR.Reservito;
using SR.TestsCore;

namespace SR.CoreImpl.Tests
{

    [TestFixture]
    public class UserContextTest
    {
        [Test]
        public void CreateContext()
        {
            AppliactionContext.Autentication.LogIn(DbUsers.MASTER_USERNAME, DbUsers.MASTER_PASSWORD);

            Assert.AreEqual(DbUsers.MASTER_USERNAME, UserContext.User.Username);
            Assert.AreEqual(DbUsers.MASTER_PASSWORD, UserContext.User.Password);

            UserContext.Logout();
        }

        [Test]
        public void CloseContext()
        {
            AppliactionContext.Autentication.LogIn(DbUsers.MASTER_USERNAME, DbUsers.MASTER_PASSWORD);

            UserContext.Logout();

            Assert.AreEqual(null, UserContext.User);
        }


        #region Tests Initialization

        [SetUp]
        public void TestInit()
        {
            new ReservitoApp();
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
    }
}
