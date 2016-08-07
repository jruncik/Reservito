using NUnit.Framework;

using SR.Core.Context;
using SR.Core.UserManagement;
using SR.Core.Users;
using SR.Model;
using SR.ModelImpl.Model;
using SR.Reservito;
using SR.TestsCore;
using System;

namespace SR.ModelImpl.Tests
{
    [TestFixture]
    public class WorkoutTest
    {
        [Test]
        public void CreateWorkout()
        {
            IWorkout workout = new Workout();

            workout.Time = new DateTime(2016, 10, 27);
            workout.Capacity = 20;
            workout.Price = 150;

            workout.Cliens.Add(_user1);
            workout.Cliens.Add(_user2);

            workout.Save();

            workout.Delete();
        }

        #region Tests Initialization

        [SetUp]
        public void TestInit()
        {
            AppliactionContext.Autentication.LogIn(DbUsers.MASTER_USERNAME, DbUsers.MASTER_PASSWORD);

            IUserManagement userManagement = AppliactionContext.UserManagement;
            _user1 = userManagement.CreateNewUser(USERNAME1, PASSWORD1, FIRSTNAME1, LASTNAME1, EMAIL1, PHONE_NUMBER1);
            _user2 = userManagement.CreateNewUser(USERNAME2, PASSWORD2, FIRSTNAME2, LASTNAME2, EMAIL2, PHONE_NUMBER2);
        }

        [TearDown]
        public void TestCleanup()
        {
            _user1.Delete();
            _user2.Delete();

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

        private IUser _user1;
        private const string USERNAME1      = "Username1";
        private const string PASSWORD1      = "Password1";
        private const string FIRSTNAME1     = "FirstName1";
        private const string LASTNAME1      = "LastName1";
        private const string EMAIL1         = "User1@Email.em";
        private const string PHONE_NUMBER1  = "+420 111 111 111";

        private IUser _user2;
        private const string USERNAME2 = "Username2";
        private const string PASSWORD2 = "Password2";
        private const string FIRSTNAME2 = "FirstName2";
        private const string LASTNAME2 = "LastName2";
        private const string EMAIL2 = "User2@Email.em";
        private const string PHONE_NUMBER2 = "+420 222 222 222";

    }
}
