using NUnit.Framework;

using SR.Core.Context;
using SR.Core.UserManagement;
using SR.Core.Users;
using SR.Model;
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
            IModelObjectFactory modelFactory = AppliactionContext.GetModekObjectFactory<IModelObjectFactory>();

            ICourse course = modelFactory.CreateCourse(_coach);
            course.Name = "Dupeme s Oldou";
            course.Price = 27;
            course.Capacity = 16;
            course.Length = 90;

            //IWorkoutInfo courseWorkoutInfo = modelFactory.CreateWorkoutInfo();
            //courseWorkoutInfo.Price = 123;
            //courseWorkoutInfo.Capacity = 5;
            //courseWorkoutInfo.Save();

            IWorkout workout = course.AddNewWorkout();

            workout.Time = new DateTime(2016, 10, 27);
            // workout.WorkoutInfo = courseWorkoutInfo;

            workout.AddClient(_user1);
            workout.AddClient(_user2);

            course.Save();
            course = null;

            IList<DbUser> dbUsers = AppliactionContext.DbOperations.GetAll<DbUser>();
            foreach (DbUser dbUser in dbUsers)
            {
                IUser newUser = new User(dbUser);
                _users.Add(newUser);
                AppliactionContext.Log.Debug(this, String.Format("User '{0}' read from DB.", newUser.Username));
            }

            course.Load();

            course.Delete();
        }

        #region Tests Initialization

        [SetUp]
        public void TestInit()
        {
            AppliactionContext.Autentication.LogIn(DbUsers.MASTER_USERNAME, DbUsers.MASTER_PASSWORD);

            IUserManagement userManagement = AppliactionContext.UserManagement;

            _coach = userManagement.CreateNewUser(COACH_USERNAME, COACH_PASSWORD, COACH_FIRSTNAME, COACH_LASTNAME, COACH_EMAIL, COACH_PHONE_NUMBER);
            _user1 = userManagement.CreateNewUser(USERNAME1, PASSWORD1, FIRSTNAME1, LASTNAME1, EMAIL1, PHONE_NUMBER1);
            _user2 = userManagement.CreateNewUser(USERNAME2, PASSWORD2, FIRSTNAME2, LASTNAME2, EMAIL2, PHONE_NUMBER2);
        }

        [TearDown]
        public void TestCleanup()
        {
            _coach.Delete();
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

        private IUser _coach;
        private const string COACH_USERNAME = "Coach";
        private const string COACH_PASSWORD = "coach";
        private const string COACH_FIRSTNAME = "Oldrich";
        private const string COACH_LASTNAME = "Pantani";
        private const string COACH_EMAIL = "Oldrich.Pantani@Email.fr";
        private const string COACH_PHONE_NUMBER = "+420 111 111 111";

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
