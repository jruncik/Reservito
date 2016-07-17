using System;
using SR.Core.Log;

namespace SR.CoreImpl.Log
{
    internal class LogWriterConsole : ILogWriter
    {
        public void WriteMessage(string logMessage, LogLevel level)
        {
            ConsoleColor currentColor = Console.ForegroundColor;

            SetTextColor(level);
            Console.WriteLine(logMessage);

            Console.ForegroundColor = currentColor;
        }

        private static void SetTextColor(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Critical:
                case LogLevel.Error:
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                break;

                case LogLevel.Warning:
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                } break;

                case LogLevel.Info:
                {
                    Console.ForegroundColor = ConsoleColor.White;
                } break;

                case LogLevel.Debug:
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                } break;

            }
        }
    }
}