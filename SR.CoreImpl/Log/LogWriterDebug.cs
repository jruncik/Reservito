using System.Diagnostics;
using SR.Core.Log;

namespace SR.CoreImpl.Log
{
    internal class LogWriterDebug : ILogWriter
    {
        public void WriteMessage(string logMessage, LogLevel level)
        {
            Debug.WriteLine(logMessage);
        }
    }
}