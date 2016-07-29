using System;

using NUnit.Framework;

using SR.Core.Context;
using SR.Core.Log;

using SR.Reservito;

namespace SR.CoreImpl.Tests
{
    [TestFixture]
    public class LogLevelTest
    {
        [Test]
        public void LogCritical()
        {
            _log.CurrentLogLevel = LogLevel.Critical;

            _logWriterMocq.IsMessageLogged = false;
            _log.Debug(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, false);

            _logWriterMocq.IsMessageLogged = false;
            _log.Info(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, false);

            _logWriterMocq.IsMessageLogged = false;
            _log.Warning(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, false);

            _logWriterMocq.IsMessageLogged = false;
            _log.Error(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, false);

            _logWriterMocq.IsMessageLogged = false;
            _log.Critical(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, true);
        }

        [Test]
        public void LogError()
        {
            _log.CurrentLogLevel = LogLevel.Error;

            _logWriterMocq.IsMessageLogged = false;
            _log.Debug(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, false);

            _logWriterMocq.IsMessageLogged = false;
            _log.Info(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, false);

            _logWriterMocq.IsMessageLogged = false;
            _log.Warning(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, false);

            _logWriterMocq.IsMessageLogged = false;
            _log.Error(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, true);

            _logWriterMocq.IsMessageLogged = false;
            _log.Critical(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, true);
        }

        [Test]
        public void LogWarning()
        {
            _log.CurrentLogLevel = LogLevel.Warning;

            _logWriterMocq.IsMessageLogged = false;
            _log.Debug(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, false);

            _logWriterMocq.IsMessageLogged = false;
            _log.Info(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, false);

            _logWriterMocq.IsMessageLogged = false;
            _log.Warning(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, true);

            _logWriterMocq.IsMessageLogged = false;
            _log.Error(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, true);

            _logWriterMocq.IsMessageLogged = false;
            _log.Critical(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, true);
        }

        [Test]
        public void LogInfo()
        {
            _log.CurrentLogLevel = LogLevel.Info;

            _logWriterMocq.IsMessageLogged = false;
            _log.Debug(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, false);

            _logWriterMocq.IsMessageLogged = false;
            _log.Info(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, true);

            _logWriterMocq.IsMessageLogged = false;
            _log.Warning(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, true);

            _logWriterMocq.IsMessageLogged = false;
            _log.Error(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, true);

            _logWriterMocq.IsMessageLogged = false;
            _log.Critical(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, true);
        }

        [Test]
        public void LogDebug()
        {
            _log.CurrentLogLevel = LogLevel.Debug;

            _logWriterMocq.IsMessageLogged = false;
            _log.Debug(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, true);

            _logWriterMocq.IsMessageLogged = false;
            _log.Info(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, true);

            _logWriterMocq.IsMessageLogged = false;
            _log.Warning(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, true);

            _logWriterMocq.IsMessageLogged = false;
            _log.Error(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, true);

            _logWriterMocq.IsMessageLogged = false;
            _log.Critical(null, MESSAGE);
            Assert.AreEqual(_logWriterMocq.IsMessageLogged, true);
        }


        #region Tests Initialization
        [OneTimeSetUpAttribute]
        public void AllTestsInit()
        {
            new ReservitoApp();

            _log = AppliactionContext.Log;

            _log.Writers.Clear();
            _logWriterMocq = new LogWriterMocq();
            _log.Writers.Add(_logWriterMocq);
        }
        #endregion

        private const String MESSAGE = "Message";
        private ILog _log;
        private LogWriterMocq _logWriterMocq;
    }
}