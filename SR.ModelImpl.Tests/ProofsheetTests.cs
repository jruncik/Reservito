using System;
using NUnit.Framework;
using TV.Core.Context;
using TV.ModelImpl.Model;
using TV.Tiskarna;

namespace TV.ModelImpl.Tests
{
    [TestFixture]
    public class ProofsheetTests
    {
        [Test]
        public void CreateContext()
        {
            Proofsheet proofsheet = new Proofsheet();
            proofsheet.Time = DateTime.Now;
            proofsheet.Passed = true;

            proofsheet.Save();
            proofsheet.Delete();
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
