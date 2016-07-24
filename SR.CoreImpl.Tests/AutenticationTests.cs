﻿using System;

using NUnit.Framework;

using SR.Core.Context;
using SR.Core.Rights;
using SR.Core.UserManagement;
using SR.CoreImpl.Autentication;

using SR.Reservito;

namespace SR.CoreImpl.Tests
{
    [TestFixture]
    public class AutenticationTests
    {
        [Test]
        public void LoginUserWithEmptyUsername()
        {
            Assert.That(() => ReservitoApp.Autentication.LogIn("", PASSWORD), Throws.TypeOf<AutenticationException>());
        }

        [Test]
        public void LoginUserWithEmptyPassword()
        {
            Assert.That(() => ReservitoApp.Autentication.LogIn(USERNAME, ""), Throws.TypeOf<AutenticationException>());
        }

        [Test]
        public void LoginUserWrongUser()
        {
            Assert.That(() => ReservitoApp.Autentication.LogIn(WRONG_USERNAME, PASSWORD), Throws.TypeOf<AutenticationException>());
        }

        [Test]
        public void LoginUserWrongPassword()
        {
            Assert.That(() => ReservitoApp.Autentication.LogIn(USERNAME, WRONG_PASSWORD), Throws.TypeOf<AutenticationException>());
        }

        [Test]
        public void LoginUser()
        {
            ReservitoApp.Autentication.LogIn(USERNAME, PASSWORD);

            Assert.AreEqual(UserContext.User.Username, USERNAME);
            Assert.AreEqual(UserContext.User.Password, PASSWORD);
        }

        [Test]
        public void LoginCaseInsensitiveUser()
        {
            ReservitoApp.Autentication.LogIn(USERNAME_CASE_INSENSITIVE, PASSWORD);

            Assert.AreEqual(UserContext.User.Username, USERNAME);
            Assert.AreEqual(UserContext.User.Password, PASSWORD);
        }

        [Test]
        public void LoginMasterUser()
        {
            ReservitoApp.Autentication.LogIn(MASTER_USERNAME, MASTER_PASSWORD);

            Assert.AreEqual(UserContext.User.Username, MASTER_USERNAME);
            Assert.AreEqual(UserContext.User.Password, MASTER_PASSWORD);
            Assert.AreEqual(UserContext.Context.IsInRole(Roles.Unknown), true);
        }

        [Test]
        public void LoginGuestUser()
        {
            ReservitoApp.Autentication.LogIn(GUEST_USERNAME, GUEST_PASSWORD);

            Assert.AreEqual(UserContext.User.Username, GUEST_USERNAME);
            Assert.AreEqual(UserContext.User.Password, GUEST_PASSWORD);
            Assert.AreEqual(UserContext.Context.IsInRole(Roles.ManageUsers), false);
        }

        #region Tests Initialization

        [SetUp]
        public void TestInit()
        {
            ReservitoApp.UserManagement.DeleteAllUsers();
            AddTestUser();
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

        private void AddTestUser()
        {
            ReservitoApp.Autentication.LogIn(MASTER_USERNAME, MASTER_PASSWORD);

            IUserManagement userManagement = ReservitoApp.UserManagement;
            userManagement.CreateNewUser(USERNAME, PASSWORD);

            UserContext.Logout();
        }

        #endregion

        private const String USERNAME = "TestNjorloj";
        private const String PASSWORD = "TestChorchoj";
        private const String USERNAME_CASE_INSENSITIVE = "TeStNjOrLoJ";

        private const String WRONG_USERNAME = "WrongUsername";
        private const String WRONG_PASSWORD = "WrongPassword";

        private const String MASTER_USERNAME = "UberNjorloj";
        private const String MASTER_PASSWORD = "IddqdIdkfa";

        private const String GUEST_USERNAME = "Guest";
        private const String GUEST_PASSWORD = "guest";
    }
}