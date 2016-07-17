using NUnit.Framework;
using SR.Core.Context;
using SR.ModelImpl.Model;
using SR.Tiskarna;

namespace SR.ModelImpl.Tests
{
    [TestFixture]
    public class AaaBbbTest
    {
        [Test]
        public void CreateContactPersone()
        {
            Bbb bbb = new Bbb();
            bbb.Age = 27;
            bbb.Save();

            try
            {
                Aaa aaa = new Aaa();

                aaa.Name = "aaa";
                aaa.B = bbb;

                aaa.Save();
                aaa.Delete();
            }
            finally
            {
                bbb.Delete();
            }
        }

    #region Tests Initialization

    [SetUp]
        public void TestInit()
        {
            TiskarnaVosahlo.Autentication.LogIn(MASTER_USERNAME, MASTER_PASSWORD);
        }

        [TearDown]
        public void TestCleanup()
        {
            UserContext.Logout();
        }

        [OneTimeSetUpAttribute]
        public void AllTestsInit()
        {
            new TiskarnaVosahlo();
        }

        [OneTimeTearDownAttribute]
        public void AllTestCleanup()
        {
        }

        #endregion

        private const string MASTER_USERNAME = "UberNjorloj";
        private const string MASTER_PASSWORD = "IddqdIdkfa";
    }
}
