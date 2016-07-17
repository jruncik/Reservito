using System.Collections.Generic;
using TV.Core.Log;

namespace TV.CoreImpl.Log
{
    public class Log : ILog
    {
        public Log()
        {
            _messageGenerator = new LogMessageGenerator();
            _writers = new List<ILogWriter>(1);
#if DEBUG
            _writers.Add(new LogWriterDebug());
#endif
        }

        public void Debug(object sender, string message)
        {
            GenAndWriteLog(LogLevel.Debug, sender, message);
        }

        public void Info(object sender, string message)
        {
            GenAndWriteLog(LogLevel.Info, sender, message);
        }

        public void Warning(object sender, string message)
        {
            GenAndWriteLog(LogLevel.Warning, sender, message);
        }

        public void Error(object sender, string message)
        {
            GenAndWriteLog(LogLevel.Error, sender, message);
        }

        public void Critical(object sender, string message)
        {
            GenAndWriteLog(LogLevel.Critical, sender, message);
        }

        public TimeLoger LogTime(object sender, string message)
        {
            return new TimeLoger(this, sender, message);
        }

        public LogLevel CurrentLogLevel
        {
            get { return _currentLogLevel; }
            set { _currentLogLevel = value; }
        }

        public IList<ILogWriter> Writers
        {
            get { return _writers; }
        }

        public ILogMessageGenerator MessageGenerator
        {
            get { return _messageGenerator; }
            set { _messageGenerator = value; }
        }

        private void GenAndWriteLog(LogLevel level, object sender, string message)
        {
            if (_messageGenerator == null || _writers.Count == 0 || !IsLogLevelEnabled(level))
            {
                return;
            }

            string logMessage = _messageGenerator.GenerateMessag(level, sender, message);
            foreach (ILogWriter logWriter in _writers)
            {
                logWriter.WriteMessage(logMessage, level);
            }
        }

        private bool IsLogLevelEnabled(LogLevel level)
        {
            return (_currentLogLevel & level) == _currentLogLevel;
        }

        private LogLevel _currentLogLevel = LogLevel.Debug;
        private ILogMessageGenerator _messageGenerator;
        private readonly IList<ILogWriter> _writers;
    }
}