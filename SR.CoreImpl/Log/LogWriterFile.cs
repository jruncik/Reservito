using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using TV.Core.Log;

namespace TV.CoreImpl.Log
{
    internal class LogWriterFile : ILogWriter
    {
        public LogWriterFile()
        {
            _writer = File.CreateText(@"C:\TV.log");

            _fileWriter = new Thread(WriteMessageInternal);
        }

        public void WriteMessage(string logMessage, LogLevel level)
        {
            _messages.Enqueue(logMessage);
        }

        private void WriteMessageInternal()
        {
            while (!_messages.IsEmpty)
            {
                String logMessage;
                if (_messages.TryDequeue(out logMessage))
                {
                    _writer.WriteLine(logMessage);
                    _writer.Flush();
                }
            }
        }

        private async void WriteMessageInternalAsync(string logMessage)
        {
            await _writer.WriteLineAsync(logMessage);
            await _writer.FlushAsync();
        }

        private readonly ConcurrentQueue<String> _messages = new ConcurrentQueue<string>();
        private readonly StreamWriter _writer;
        private readonly Thread _fileWriter;
    }
}