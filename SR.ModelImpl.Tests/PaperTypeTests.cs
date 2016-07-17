using System.Drawing;
using NUnit.Framework;
using SR.ModelImpl.Model;
using SR.Core.Context;
using SR.Tiskarna;

namespace SR.ModelImpl.Tests
{
    [TestFixture]
    public class PaperTypeTests
    {
        [Test]
        public void CreatePaperType()
        {
            PaperType paperType = new PaperType();
            paperType.Color = Color.Red;
            paperType.Type = "Karticka";

            paperType.Save();
            paperType.Delete();
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
