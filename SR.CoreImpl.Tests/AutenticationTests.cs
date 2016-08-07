using System;

using NUnit.Framework;

using SR.Core.Context;
using SR.Core.Rights;
using SR.Core.UserManagement;
using SR.CoreImpl.Autentication;

using SR.Reservito;
using SR.TestsCore;

namespace SR.CoreImpl.Tests
{
    [TestFixture]
    public class AutenticationTests
    {
        [Test]
        public void LoginUserWithEmptyUsername()
        {
            Assert.That(() => AppliactionContext.Autentication.LogIn("", PASSWORD), Throws.TypeOf<AutenticationException>());
        }

        [Test]
        public void LoginUserWithEmptyPassword()
        {
            Assert.That(() => AppliactionContext.Autentication.LogIn(USERNAME, ""), Throws.TypeOf<AutenticationException>());
        }

        [Test]
        public void LoginUserWrongUser()
        {
            Assert.That(() => AppliactionContext.Autentication.LogIn(WRONG_USERNAME, PASSWORD), Throws.TypeOf<AutenticationException>());
        }

        [Test]
        public void LoginUserWrongPassword()
        {
            Assert.That(() => AppliactionContext.Autentication.LogIn(USERNAME, WRONG_PASSWORD), Throws.TypeOf<AutenticationException>());
        }

        [Test]
        public void LoginUser()
        {
            AppliactionContext.Autentication.LogIn(USERNAME, PASSWORD);

            Assert.AreEqual(UserContext.User.Username, USERNAME);
            Assert.AreEqual(UserContext.User.Password, PASSWORD);
        }

        [Test]
        public void LoginCaseInsensitiveUser()
        {
            AppliactionContext.Autentication.LogIn(USERNAME_CASE_INSENSITIVE, PASSWORD);

            Assert.AreEqual(UserContext.User.Username, USERNAME);
            Assert.AreEqual(UserContext.User.Password, PASSWORD);
        }

        [Test]
        public void LoginMasterUser()
        {
            AppliactionContext.Autentication.LogIn(DbUsers.MASTER_USERNAME, DbUsers.MASTER_PASSWORD);

            Assert.AreEqual(UserContext.User.Username, DbUsers.MASTER_USERNAME);
            Assert.AreEqual(UserContext.User.Password, DbUsers.MASTER_PASSWORD);
            Assert.AreEqual(UserContext.Context.IsInRole(Roles.Unknown), true);
        }

        [Test]
        public void LoginGuestUser()
        {
            AppliactionContext.Autentication.LogIn(DbUsers.GUEST_USERNAME, DbUsers.GUEST_PASSWORD);

            Assert.AreEqual(UserContext.User.Username, DbUsers.GUEST_USERNAME);
            Assert.AreEqual(UserContext.User.Password, DbUsers.GUEST_PASSWORD);
            Assert.AreEqual(UserContext.Context.IsInRole(Roles.ManageUsers), false);
        }

        #region Tests Initialization

        [SetUp]
        public void TestInit()
        {
            AppliactionContext.UserManagement.DeleteAllUsers();
            AddTestUser();
        }

        [TearDown]
        public void TestCleanup()
        {
            UserContext.Logout();
            AppliactionContext.UserManagement.DeleteAllUsers();
        }

        [OneTimeSetUpAttribute]
        public void AllTestsInit()
        {
            new ReservitoApp();
        }

        [OneTimeTearDownAttribute]
        public void AllTestCleanup()
        {
            AppliactionContext.UserManagement.DeleteAllUsers();
        }

        private void AddTestUser()
        {
            AppliactionContext.Autentication.LogIn(DbUsers.MASTER_USERNAME, DbUsers.MASTER_PASSWORD);

            IUserManagement userManagement = AppliactionContext.UserManagement;
            userManagement.CreateNewUser(USERNAME, PASSWORD, FIRSTNAME, LASTNAME, EMAIL, PHONE_NUMBER);

            UserContext.Logout();
        }

        #endregion

        private const string FIRSTNAME = "FirstName";
        private const string LASTNAME = "LastName";
        private const string EMAIL = "Email@Email.em";
        private const string PHONE_NUMBER = "+420 123 456 789";

        private const string USERNAME = "TestNjorloj";
        private const string PASSWORD = "TestChorchoj";
        private const string USERNAME_CASE_INSENSITIVE = "TeStNjOrLoJ";


        private const string WRONG_USERNAME = "WrongUsername";
        private const string WRONG_PASSWORD = "WrongPassword";
    }
}