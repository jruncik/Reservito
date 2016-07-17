using System;
using System.Collections.Generic;
using NUnit.Framework;
using SR.Core;
using SR.Core.Context;
using SR.Core.Rights;
using SR.Model;
using SR.Tiskarna;

namespace SR.CoreImpl.Tests
{
    [TestFixture]
    public class TiskarnaVosahloPaperFormatsTests
    {
        [Test]
        public void AddBuildinFormat()
        {
            IPaperFormats paperFormats = TiskarnaVosahlo.PaperFormats;

            Assert.That(() => paperFormats.AddFormat(BUILIN_FORMAT_NAME_A4, EXPECTED_WIDTH, EXPECTED_HEIGHT), Throws.TypeOf<TvException>());
        }

        [Test]
        public void AddNewFormatWithoutRights()
        {
            TiskarnaVosahlo.Autentication.LogIn(GUEST_USERNAME, GUEST_PASSWORD);
            IPaperFormats paperFormats = TiskarnaVosahlo.PaperFormats;

            Assert.That(() => paperFormats.AddFormat(NEW_FORMAT, EXPECTED_WIDTH, EXPECTED_HEIGHT), Throws.TypeOf<RightsException>());
        }

        [Test]
        public void AddNewFormat()
        {
            IPaperFormats paperFormats = TiskarnaVosahlo.PaperFormats;
            IPaperFormat newPaperformat = paperFormats.AddFormat(NEW_FORMAT, EXPECTED_WIDTH, EXPECTED_HEIGHT);

            Assert.AreEqual(NEW_FORMAT, newPaperformat.Name);
            Assert.AreEqual(EXPECTED_WIDTH, newPaperformat.Size.Width);
            Assert.AreEqual(EXPECTED_HEIGHT, newPaperformat.Size.Height);
        }

        #region Tests Initialization

        [SetUp]
        public void TestInit()
        {
            TiskarnaVosahlo.Autentication.LogIn(MASTER_USERNAME, MASTER_PASSWORD);

            DeleteAllCustomFormats();
        }

        [TearDown]
        public void TestCleanup()
        {
            DeleteAllCustomFormats();
            UserContext.Logout();
        }

        [OneTimeSetUpAttribute]
        public void AllTestsInit()
        {
            new TiskarnaVosahlo();
        }

        private void DeleteAllCustomFormats()
        {
            IList<IPaperFormat> paperFormatsToDelete = FetchFormatsToDelete();
            while (paperFormatsToDelete.Count > 0)
            {
                IPaperFormat formatToDelete = paperFormatsToDelete[0];
                TiskarnaVosahlo.PaperFormats.DeleteFormat(formatToDelete);
                paperFormatsToDelete.Remove(formatToDelete);
            }
        }

        private IList<IPaperFormat> FetchFormatsToDelete()
        {
            IList<IPaperFormat> paperFormatsToDelete = new List<IPaperFormat>();
            IList<IPaperFormat> paperFormats = TiskarnaVosahlo.PaperFormats.Formats;

            foreach (IPaperFormat paperFormat in paperFormats)
            {
                if (!paperFormat.IsBuildIn)
                {
                    paperFormatsToDelete.Add(paperFormat);
                }
            }
            return paperFormatsToDelete;
        }

        #endregion

        private const String MASTER_USERNAME = "UberNjorloj";
        private const String MASTER_PASSWORD = "IddqdIdkfa";

        private const String GUEST_USERNAME = "Guest";
        private const String GUEST_PASSWORD = "guest";

        private static readonly string NEW_FORMAT = "NewFormat";
        private static readonly string BUILIN_FORMAT_NAME_A4 = "A4";
        private static readonly int EXPECTED_WIDTH = 100;
        private static readonly int EXPECTED_HEIGHT = 200;
    }
}