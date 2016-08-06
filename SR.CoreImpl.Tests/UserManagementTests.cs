using System;

using NUnit.Framework;

using SR.Core.Context;
using SR.Core.Rights;
using SR.Core.UserManagement;
using SR.Core.Users;

using SR.Reservito;
using SR.TestsCore;

namespace SR.CoreImpl.Tests
{
    [TestFixture]
    public class UserManagementTests
    {
        [Test]
        public void CreateNewUserEmptyName()
        {
            ReservitoApp.Autentication.LogIn(DbUsers.MASTER_USERNAME, DbUsers.MASTER_PASSWORD);

            IUserManagement userManagement = ReservitoApp.UserManagement;
            Assert.That(() => userManagement.CreateNewUser("", PASSWORD, FIRSTNAME, LASTNAME, EMAIL, PHONE_NUMBER), Throws.TypeOf<UserManagementException>());
        }

        [Test]
        public void CreateNewUserEmptyPassword()
        {
            ReservitoApp.Autentication.LogIn(DbUsers.MASTER_USERNAME, DbUsers.MASTER_PASSWORD);

            IUserManagement userManagement = ReservitoApp.UserManagement;
            Assert.That(() => userManagement.CreateNewUser(USERNAME, "", FIRSTNAME, LASTNAME, EMAIL, PHONE_NUMBER), Throws.TypeOf<UserManagementException>());
        }

        [Test]
        public void CreateNewUserEmptyFirtstName()
        {
            ReservitoApp.Autentication.LogIn(DbUsers.MASTER_USERNAME, DbUsers.MASTER_PASSWORD);

            IUserManagement userManagement = ReservitoApp.UserManagement;
            Assert.That(() => userManagement.CreateNewUser(USERNAME, PASSWORD, "", LASTNAME, EMAIL, PHONE_NUMBER), Throws.TypeOf<UserManagementException>());
        }

        [Test]
        public void CreateNewUserEmptyLastName()
        {
            ReservitoApp.Autentication.LogIn(DbUsers.MASTER_USERNAME, DbUsers.MASTER_PASSWORD);

            IUserManagement userManagement = ReservitoApp.UserManagement;
            Assert.That(() => userManagement.CreateNewUser(USERNAME, PASSWORD, FIRSTNAME, "", EMAIL, PHONE_NUMBER), Throws.TypeOf<UserManagementException>());
        }

        [Test]
        public void CreateNewUserEmptyEmail()
        {
            ReservitoApp.Autentication.LogIn(DbUsers.MASTER_USERNAME, DbUsers.MASTER_PASSWORD);

            IUserManagement userManagement = ReservitoApp.UserManagement;
            Assert.That(() => userManagement.CreateNewUser(USERNAME, PASSWORD, FIRSTNAME, LASTNAME, "", PHONE_NUMBER), Throws.TypeOf<UserManagementException>());
        }

        [Test]
        public void CreateNewUserAlreadyExist()
        {
            ReservitoApp.Autentication.LogIn(DbUsers.MASTER_USERNAME, DbUsers.MASTER_PASSWORD);

            IUserManagement userManagement = ReservitoApp.UserManagement;
            IUser newUser = userManagement.CreateNewUser(USERNAME, PASSWORD, FIRSTNAME, LASTNAME, EMAIL, PHONE_NUMBER);

            try
            {
                Assert.That(() => userManagement.CreateNewUser(USERNAME, PASSWORD, FIRSTNAME, LASTNAME, EMAIL, PHONE_NUMBER), Throws.TypeOf<UserManagementException>());
            }
            finally
            {
                userManagement.DeleteUser(newUser);
            }
        }

        [Test]
        public void CreateNewUserWithoutRights()
        {
            ReservitoApp.Autentication.LogIn(DbUsers.GUEST_USERNAME, DbUsers.GUEST_PASSWORD);
            IUserManagement userManagement = ReservitoApp.UserManagement;

            Assert.That(() => userManagement.CreateNewUser(USERNAME, PASSWORD, FIRSTNAME, LASTNAME, EMAIL, PHONE_NUMBER), Throws.TypeOf<RightsException>());
        }

        [Test]
        public void CreateNewUser()
        {
            ReservitoApp.Autentication.LogIn(DbUsers.MASTER_USERNAME, DbUsers.MASTER_PASSWORD);

            IUserManagement userManagement = ReservitoApp.UserManagement;
            IUser newUser = userManagement.CreateNewUser(USERNAME, PASSWORD, FIRSTNAME, LASTNAME, EMAIL, PHONE_NUMBER);

            Assert.AreEqual(newUser.Username, USERNAME);
            Assert.AreEqual(newUser.Password, PASSWORD);
            Assert.AreEqual(newUser.Active, false);

            userManagement.DeleteUser(newUser);
        }

        [Test]
        public void SaveUser()
        {
            ReservitoApp.Autentication.LogIn(DbUsers.MASTER_USERNAME, DbUsers.MASTER_PASSWORD);

            IUserManagement userManagement = ReservitoApp.UserManagement;
            IUser newUser = userManagement.CreateNewUser(USERNAME, PASSWORD, FIRSTNAME, LASTNAME, EMAIL, PHONE_NUMBER);

            Assert.True(userManagement.Users.Contains(newUser));

            userManagement.DeleteUser(newUser);
        }

        [Test]
        public void ReloadUserFromDb()
        {
            ReservitoApp.Autentication.LogIn(DbUsers.MASTER_USERNAME, DbUsers.MASTER_PASSWORD);

            IUserManagement userManagement = ReservitoApp.UserManagement;
            IUser newUser = userManagement.CreateNewUser(USERNAME, PASSWORD, FIRSTNAME, LASTNAME, EMAIL, PHONE_NUMBER);

            newUser.Username = NEW_USERNAME;
            newUser.Password = NEW_PASSWORD;

            newUser.Save();

            IUser newUserOldName = userManagement.TryFindUserByUsername(USERNAME);
            Assert.AreEqual(newUserOldName.Id, Guid.Empty);

            IUser newUserReloaded = userManagement.TryFindUserByUsername(NEW_USERNAME);
            Assert.AreEqual(newUserReloaded.Username, NEW_USERNAME);
            Assert.AreEqual(newUserReloaded.Password, NEW_PASSWORD);

            userManagement.DeleteUser(newUser);
        }

        [Test]
        public void DeleteUser()
        {
            ReservitoApp.Autentication.LogIn(DbUsers.MASTER_USERNAME, DbUsers.MASTER_PASSWORD);

            IUserManagement userManagement = ReservitoApp.UserManagement;
            IUser newUser = userManagement.CreateNewUser(USERNAME, PASSWORD, FIRSTNAME, LASTNAME, EMAIL, PHONE_NUMBER);

            userManagement.DeleteUser(newUser);

            IUser deletedUser = userManagement.TryFindUserByUsername(USERNAME);

            Assert.AreEqual(deletedUser.Id, Guid.Empty);
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
        private const string USERNAME = "TestNjorloj";
        private const string PASSWORD = "TestChorchoj";
        private const string FIRSTNAME = "FirstName";
        private const string LASTNAME = "LastName";
        private const string EMAIL = "Email@Email.em";
        private const string PHONE_NUMBER = "+420 123 456 789";

        private const string NEW_USERNAME = "TestNewUsername";
        private const string NEW_PASSWORD = "TestNewPassword";
    }
}