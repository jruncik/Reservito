using NUnit.Framework;
using System;
using SR.Core.Context;
using SR.ModelImpl.Model;
using SR.Tiskarna;

namespace SR.ModelImpl.Tests
{
    [TestFixture]
    public class OrderTest
    {
        [Test]
        public void CreateOrder()
        {
            ContactPerson cp = new ContactPerson();
            cp.FirstName = "Jarosav";
            cp.LastName = "Runcik";
            cp.Email = "J.Runcik@seznam.cz";
            cp.PhoneNumber = "+420 602 658 348";

            cp.Save();

            PaperType paperType = new PaperType();
            paperType.Color = System.Drawing.Color.Blue;
            paperType.Type = "Stitek";

            paperType.Save();

            Proofsheet proofsheet = new Proofsheet();
            proofsheet.Time = DateTime.Now;
            proofsheet.Passed = true;

            proofsheet.Save();



            try
            {
                Order order = new Order();

                order.Contact = cp;
                order.Format = TiskarnaVosahlo.PaperFormats.GetFormat("A4");
                order.PaperType = paperType;
                order.Proofsheet = proofsheet;

                order.Save();
                order.Delete();
            }
            finally
            {
                proofsheet.Delete();
                paperType.Delete();
                cp.Delete();
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
