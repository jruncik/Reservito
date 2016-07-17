using System;

namespace SR.Core.Log
{
    public class TimeLoger : DisposableBase
    {
        public TimeLoger(ILog log, object sourceObj, string message)
        {
            _log = log;
            _sourceObj = sourceObj;
            _message = message;
        }

        protected override void DisposeInternal()
        {
            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - _startTime;

            _log.Debug(_sourceObj, String.Format("{0}: [{1} ms]", _message, duration.Milliseconds));
        }

        private readonly ILog _log;
        private readonly object _sourceObj;
        private readonly String _message;
        private readonly DateTime _startTime = DateTime.Now;
    }
}