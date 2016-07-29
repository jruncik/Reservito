using NUnit.Framework;

using SR.Core.Context;
using SR.ModelImpl.Model;

using SR.Reservito;
using SR.TestsCore;

namespace SR.ModelImpl.Tests
{
    [TestFixture]
    public class ContactPersoneTests
    {
        [Test]
        public void CreateContactPersone()
        {
            ContactPerson cp = new ContactPerson();
            cp.FirstName = "Jarosav";
            cp.LastName = "Runcik";
            cp.Email = "J.Runcik@seznam.cz";
            cp.PhoneNumber = "+420 602 658 348";

            cp.Save();
            cp.Delete();
        }

        #region Tests Initialization

        [SetUp]
        public void TestInit()
        {
            ReservitoApp.Autentication.LogIn(DbUsers.MASTER_USERNAME, DbUsers.MASTER_PASSWORD);
        }

        [TearDown]
        public void TestCleanup()
        {
            UserContext.Logout();
        }

        [OneTimeSetUpAttribute]
        public void AllTestsInit()
        {
            new ReservitoApp();
        }

        [OneTimeTearDownAttribute]
        public void AllTestCleanup()
        {
        }

        #endregion
    }
}
