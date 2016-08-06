using System;
using System.Diagnostics;

namespace SR.Core
{
    public class EasyDispose : IDisposable
    {
        public EasyDispose()
        {
        }

        public EasyDispose(Action doManagedDispose)
        {
            _disposeManaged = doManagedDispose;
        }

        public EasyDispose(Action doManagedDispose, Action doUnmanagedDispose)
        {
            _disposeManaged = doManagedDispose;
            _disposeUnmanaged = doUnmanagedDispose;
        }

        ~EasyDispose()
        {
            // Debug.Assert(_disposed, String.Format("Dispose me! - '{0}'", GetType().Name));
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public bool IsDisposed
        {
            get { return _disposed; }
        }

        public void AssureNotDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        protected virtual void DestroyManagedResources()
        {
            if (_disposeManaged != null)
            {
                _disposeManaged();
            }
        }

        protected virtual void DestroyUnmanagedResources()
        {
            if (_disposeUnmanaged != null)
            {
                _disposeUnmanaged();
            }
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    DestroyManagedResources();
                }
                _disposed = true;
            }
        }

        private bool _disposed;
        private Action _disposeManaged;
        private Action _disposeUnmanaged;
    }
}
