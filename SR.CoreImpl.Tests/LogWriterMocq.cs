using SR.Core.Log;

namespace SR.CoreImpl.Tests
{
    public class LogWriterMocq : ILogWriter
    {
        public void WriteMessage(string logMessage, LogLevel level)
        {
            IsMessageLogged = true;
        }

        public bool IsMessageLogged
        {
            get; set;
        }
    }
}