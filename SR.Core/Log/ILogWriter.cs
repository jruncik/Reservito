namespace SR.Core.Log
{
    public interface ILogWriter
    {
        void WriteMessage(string logMessage, LogLevel level);
    }
}