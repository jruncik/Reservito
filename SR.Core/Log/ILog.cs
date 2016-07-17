using System.Collections.Generic;

namespace SR.Core.Log
{
    public interface ILog
    {
        void Debug(object sender, string message);
        void Info(object sender, string message);
        void Warning(object sender, string message);
        void Error(object sender, string message);
        void Critical(object sender, string message);

        TimeLoger LogTime(object sender, string message);

        LogLevel CurrentLogLevel { get; set; }
        IList<ILogWriter> Writers { get; }
        ILogMessageGenerator MessageGenerator { get; set; }
    }
}