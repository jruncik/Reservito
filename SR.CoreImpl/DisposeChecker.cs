using System;
using System.Diagnostics;

namespace SR.CoreImpl
{
    public abstract class DisposeChecker : IDisposable
    {
        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
            }

            _disposed = true;
        }

        protected abstract void DisposeInternal();

        ~DisposeChecker()
        {
            Debug.Assert(_disposed, "Dispose me!");

            Dispose(false);
        }
    }
}