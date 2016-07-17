using SR.Core.Log;

namespace SR.CoreImpl.Tests
{
    public class LogWriterTest : ILogWriter
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