using System;
using NUnit.Framework;
using TV.Core.Context;
using TV.Tiskarna;
using TV.Core.Log;

namespace TV.CoreImpl.Tests
{
    [TestFixture]
    public class LogLevelTest
    {
        [Test]
        public void LogCritical()
        {
            _log.CurrentLogLevel = LogLevel.Critical;

            _logWriterTest.IsMessageLogged = false;
            _log.Debug(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, false);

            _logWriterTest.IsMessageLogged = false;
            _log.Info(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, false);

            _logWriterTest.IsMessageLogged = false;
            _log.Warning(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, false);

            _logWriterTest.IsMessageLogged = false;
            _log.Error(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, false);

            _logWriterTest.IsMessageLogged = false;
            _log.Critical(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, true);
        }

        [Test]
        public void LogError()
        {
            _log.CurrentLogLevel = LogLevel.Error;

            _logWriterTest.IsMessageLogged = false;
            _log.Debug(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, false);

            _logWriterTest.IsMessageLogged = false;
            _log.Info(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, false);

            _logWriterTest.IsMessageLogged = false;
            _log.Warning(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, false);

            _logWriterTest.IsMessageLogged = false;
            _log.Error(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, true);

            _logWriterTest.IsMessageLogged = false;
            _log.Critical(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, true);
        }

        [Test]
        public void LogWarning()
        {
            _log.CurrentLogLevel = LogLevel.Warning;

            _logWriterTest.IsMessageLogged = false;
            _log.Debug(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, false);

            _logWriterTest.IsMessageLogged = false;
            _log.Info(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, false);

            _logWriterTest.IsMessageLogged = false;
            _log.Warning(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, true);

            _logWriterTest.IsMessageLogged = false;
            _log.Error(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, true);

            _logWriterTest.IsMessageLogged = false;
            _log.Critical(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, true);
        }

        [Test]
        public void LogInfo()
        {
            _log.CurrentLogLevel = LogLevel.Info;

            _logWriterTest.IsMessageLogged = false;
            _log.Debug(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, false);

            _logWriterTest.IsMessageLogged = false;
            _log.Info(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, true);

            _logWriterTest.IsMessageLogged = false;
            _log.Warning(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, true);

            _logWriterTest.IsMessageLogged = false;
            _log.Error(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, true);

            _logWriterTest.IsMessageLogged = false;
            _log.Critical(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, true);
        }

        [Test]
        public void LogDebug()
        {
            _log.CurrentLogLevel = LogLevel.Debug;

            _logWriterTest.IsMessageLogged = false;
            _log.Debug(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, true);

            _logWriterTest.IsMessageLogged = false;
            _log.Info(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, true);

            _logWriterTest.IsMessageLogged = false;
            _log.Warning(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, true);

            _logWriterTest.IsMessageLogged = false;
            _log.Error(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, true);

            _logWriterTest.IsMessageLogged = false;
            _log.Critical(null, MESSAGE);
            Assert.AreEqual(_logWriterTest.IsMessageLogged, true);
        }


        #region Tests Initialization
        [OneTimeSetUpAttribute]
        public void AllTestsInit()
        {
            new TiskarnaVosahlo();

            _log = AppliactionContext.Log;

            _log.Writers.Clear();
            _logWriterTest = new LogWriterTest();
            _log.Writers.Add(_logWriterTest);
        }
        #endregion

        private const String MESSAGE = "Message";
        private ILog _log;
        private LogWriterTest _logWriterTest;
    }
}