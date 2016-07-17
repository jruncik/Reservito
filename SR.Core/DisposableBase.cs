using System;
using System.Diagnostics;

namespace SR.Core
{
    public abstract class DisposableBase : IDisposable
    {
        protected abstract void DisposeInternal();

        ~DisposableBase()
        {
            Debug.Assert(_disposed, "Dispose me!");
            Dispose(false);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DisposeInternal();
                }
                _disposed = true;
            }
        }

        private bool _disposed;
    }
}