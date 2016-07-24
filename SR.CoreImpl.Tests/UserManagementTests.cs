using System;

using NUnit.Framework;

using SR.Core.Context;
using SR.Core.Rights;
using SR.Core.UserManagement;
using SR.Core.Users;

using SR.Reservito;

namespace SR.CoreImpl.Tests
{
    [TestFixture]
    public class UserManagementTests
    {
        [Test]
        public void CreateNewUserEmptyName()
        {
            ReservitoApp.Autentication.LogIn(MASTER_USERNAME, MASTER_PASSWORD);

            IUserManagement userManagement = ReservitoApp.UserManagement;
            Assert.That(() => userManagement.CreateNewUser("", PASSWORD), Throws.TypeOf<UserManagementException>());
        }

        [Test]
        public void CreateNewUserEmptyPassword()
        {
            ReservitoApp.Autentication.LogIn(MASTER_USERNAME, MASTER_PASSWORD);

            IUserManagement userManagement = ReservitoApp.UserManagement;
            Assert.That(() => userManagement.CreateNewUser(USERNAME, ""), Throws.TypeOf<UserManagementException>());
        }

        [Test]
        public void CreateNewUserAlreadyExist()
        {
            ReservitoApp.Autentication.LogIn(MASTER_USERNAME, MASTER_PASSWORD);

            IUserManagement userManagement = ReservitoApp.UserManagement;
            IUser newUser = userManagement.CreateNewUser(USERNAME, PASSWORD);

            try
            {
                Assert.That(() => userManagement.CreateNewUser(USERNAME, PASSWORD), Throws.TypeOf<UserManagementException>());
            }
            finally
            {
                userManagement.DeleteUser(newUser);
            }
        }

        [Test]
        public void CreateNewUserWithoutRights()
        {
            ReservitoApp.Autentication.LogIn(GUEST_USERNAME, GUEST_PASSWORD);
            IUserManagement userManagement = ReservitoApp.UserManagement;

            Assert.That(() => userManagement.CreateNewUser(USERNAME, PASSWORD), Throws.TypeOf<RightsException>());
        }

        [Test]
        public void CreateNewUser()
        {
            ReservitoApp.Autentication.LogIn(MASTER_USERNAME, MASTER_PASSWORD);

            IUserManagement userManagement = ReservitoApp.UserManagement;
            IUser newUser = userManagement.CreateNewUser(USERNAME, PASSWORD);

            Assert.AreEqual(newUser.Username, USERNAME);
            Assert.AreEqual(newUser.Password, PASSWORD);

            userManagement.DeleteUser(newUser);
        }

        [Test]
        public void SaveUser()
        {
            ReservitoApp.Autentication.LogIn(MASTER_USERNAME, MASTER_PASSWORD);

            IUserManagement userManagement = ReservitoApp.UserManagement;
            IUser newUser = userManagement.CreateNewUser(USERNAME, PASSWORD);

            Assert.True(userManagement.Users.Contains(newUser));

            userManagement.DeleteUser(newUser);
        }

        [Test]
        public void UpdateUserFromDb()
        {
            ReservitoApp.Autentication.LogIn(MASTER_USERNAME, MASTER_PASSWORD);

            IUserManagement userManagement = ReservitoApp.UserManagement;
            IUser newUser = userManagement.CreateNewUser(USERNAME, PASSWORD);

            newUser.Username = NEW_USERNAME;
            newUser.Password = NEW_PASSWORD;

            newUser.Save();
            newUser.Reload();

            Assert.AreEqual(newUser.Username, NEW_USERNAME);
            Assert.AreEqual(newUser.Password, NEW_PASSWORD);

            userManagement.DeleteUser(newUser);
        }

        [Test]
        public void UpdateCancleUser()
        {
            ReservitoApp.Autentication.LogIn(MASTER_USERNAME, MASTER_PASSWORD);

            IUserManagement userManagement = ReservitoApp.UserManagement;
            IUser newUser = userManagement.CreateNewUser(USERNAME, PASSWORD);

            newUser.Username = NEW_USERNAME;
            newUser.Password = NEW_PASSWORD;

            newUser.Reload();

            Assert.AreEqual(newUser.Username, USERNAME);
            Assert.AreEqual(newUser.Password, PASSWORD);

            userManagement.DeleteUser(newUser);
        }

        [Test]
        public void DeleteUser()
        {
            ReservitoApp.Autentication.LogIn(MASTER_USERNAME, MASTER_PASSWORD);

            IUserManagement userManagement = ReservitoApp.UserManagement;
            IUser newUser = userManagement.CreateNewUser(USERNAME, PASSWORD);

            userManagement.DeleteUser(newUser);
        }

        #region Tests Initialization

        [SetUp]
        public void TestInit()
        {
            ReservitoApp.UserManagement.DeleteAllUsers();
            UserContext.Logout();
        }

        [TearDown]
        public void TestCleanup()
        {
            UserContext.Logout();
            ReservitoApp.UserManagement.DeleteAllUsers();
        }

        [OneTimeSetUpAttribute]
        public void AllTestsInit()
        {
            new ReservitoApp();
        }

        [OneTimeTearDownAttribute]
        public void AllTestCleanup()
        {
            ReservitoApp.UserManagement.DeleteAllUsers();
        }

        #endregion
        private const String USERNAME = "TestNjorloj";
        private const String PASSWORD = "TestChorchoj";

        private const String MASTER_USERNAME = "UberNjorloj";
        private const String MASTER_PASSWORD = "IddqdIdkfa";

        private const String GUEST_USERNAME = "Guest";
        private const String GUEST_PASSWORD = "guest";

        private const String NEW_USERNAME = "TestNewUsername";
        private const String NEW_PASSWORD = "TestNewPassword";
    }
}