using System;
using System.Text;
using TV.Core.Log;

namespace TV.CoreImpl.Log
{
    internal class LogMessageGenerator : ILogMessageGenerator
    {
        public string GenerateMessag(LogLevel level, object sender, string message)
        {
            _logMessageBuilder.Length = 0;

            _logMessageBuilder.Append(GetLevelString(level));
            _logMessageBuilder.Append(": [");
            _logMessageBuilder.Append(String.Format("{0:MM/dd/yyy hh:mm:ss.fff}", DateTime.Now));
            _logMessageBuilder.Append("] - [");
            if (sender != null)
            {
                _logMessageBuilder.Append(sender.GetType().FullName);
            }
            else
            {
                _logMessageBuilder.Append("null");
            }
            _logMessageBuilder.Append("] - ");
            _logMessageBuilder.Append(message);

            return _logMessageBuilder.ToString();
        }

        private string GetLevelString(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    return "Debug";

                case LogLevel.Info:
                    return "Info";

                case LogLevel.Warning:
                    return "Warning";

                case LogLevel.Error:
                    return "Error";

                case LogLevel.Critical:
                    return "Critical";
            }

            throw new AggregateException(string.Format("Unknown LogLevel type {0}", level));
        }

        private readonly StringBuilder _logMessageBuilder = new StringBuilder(256);
    }
}