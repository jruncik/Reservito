namespace TV.Core.Log
{
    public interface ILogWriter
    {
        void WriteMessage(string logMessage, LogLevel level);
    }
}