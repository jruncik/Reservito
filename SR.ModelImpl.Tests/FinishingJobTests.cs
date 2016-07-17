using System;
using NUnit.Framework;
using SR.Core.Context;
using SR.ModelImpl.Model;
using SR.Tiskarna;

namespace SR.ModelImpl.Tests
{
    [TestFixture]
    public class FinishingJobTests
    {
        [Test]
        public void TestNumberingFlag()
        {
            FinishingJob finishingJob = new FinishingJob();
            TestSingleFlag(finishingJob, FinishingJobFlag.Numbering, () => finishingJob.Numbering, value => finishingJob.Numbering = value);
        }

        [Test]
        public void TestFolddingFlag()
        {
            FinishingJob finishingJob = new FinishingJob();
            TestSingleFlag(finishingJob, FinishingJobFlag.Foldding, () => finishingJob.Foldding, value => finishingJob.Foldding = value);
        }

        [Test]
        public void TestPerforationFlag()
        {
            FinishingJob finishingJob = new FinishingJob();
            TestSingleFlag(finishingJob, FinishingJobFlag.Perforation, () => finishingJob.Perforation, value => finishingJob.Perforation = value);
        }

        [Test]
        public void TestCutFlag()
        {
            FinishingJob finishingJob = new FinishingJob();
            TestSingleFlag(finishingJob, FinishingJobFlag.Cut, () => finishingJob.Cut, value => finishingJob.Cut = value);
        }

        [Test]
        public void TestBigovaniFlag()
        {
            FinishingJob finishingJob = new FinishingJob();
            TestSingleFlag(finishingJob, FinishingJobFlag.Bigovani, () => finishingJob.Bigovani, value => finishingJob.Bigovani = value);
        }

        [Test]
        public void TestAssemblingFlag()
        {
            FinishingJob finishingJob = new FinishingJob();
            TestSingleFlag(finishingJob, FinishingJobFlag.Assembling, () => finishingJob.Assembling, value => finishingJob.Assembling = value);
        }

        [Test]
        public void TestGluingFlag()
        {
            FinishingJob finishingJob = new FinishingJob();
            TestSingleFlag(finishingJob, FinishingJobFlag.Gluing, () => finishingJob.Gluing, value => finishingJob.Gluing = value);
        }

        [Test]
        public void TestNeedlingFlag()
        {
            FinishingJob finishingJob = new FinishingJob();
            TestSingleFlag(finishingJob, FinishingJobFlag.Needling, () => finishingJob.Needling, value => finishingJob.Needling = value);
        }

        [Test]
        public void TestLaminationFlag()
        {
            FinishingJob finishingJob = new FinishingJob();
            TestSingleFlag(finishingJob, FinishingJobFlag.Lamination, () => finishingJob.Lamination, value => finishingJob.Lamination = value);
        }

        [Test]
        public void TestSaveDelet()
        {
            FinishingJob finishingJob = new FinishingJob();
            finishingJob.Numbering = true;
            finishingJob.Assembling = true;
            finishingJob.Other = "Jine zpracovani";

            finishingJob.Save();
            finishingJob.Delete();
        }

        private static void TestSingleFlag(FinishingJob finishingJob, FinishingJobFlag testFlag, Func<bool> getFlag, Action<bool> setFlag)
        {
            Assert.IsFalse(getFlag());
            Assert.AreEqual(FinishingJobFlag.None, finishingJob.Flags);

            setFlag(true);
            Assert.IsTrue(getFlag());
            Assert.AreEqual(testFlag, finishingJob.Flags);

            setFlag(false);
            Assert.IsFalse(getFlag());
            Assert.AreEqual(FinishingJobFlag.None, finishingJob.Flags);
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

