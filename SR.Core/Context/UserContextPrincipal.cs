using System;
using System.Diagnostics;
using System.Security.Principal;

namespace SR.Core.Context
{
    public class UserContextPrincipal : IPrincipal, IDisposable
    {
        public UserContextPrincipal(UserContextData data)
        {
            
            _context = new WeakReference<UserContextData>(data);
        }

        // it must be weak reference as the principal is being captured by various threads 
        // they refer to the context data forever and cause serious memory leaks
        public UserContextData Context
        {
            get
            {
                UserContextData context;
                _context.TryGetTarget(out context);
                return context;
            }
        }

        public SessionId SessionId
        {
            get
            {
                UserContextData contextData = Context;
                if (contextData != null)
                {
                    return contextData.SessionId;
                }
                return SessionId.Empty;
            }
        }

        public IPrincipal SecurityPrincipal
        {
            get
            {
                UserContextData contextData = Context;
                if (contextData != null)
                {
                    return contextData;
                }
                return EmptyPrincipal;
            }
        }

        public IIdentity Identity
        {
            get
            {
                UserContextData contextData = Context;
                if (contextData != null)
                {
                    return contextData;
                }
                return EmptyIdentity;
            }
        }

        public bool IsInRole(string role)
        {
            UserContextData contextData = Context;
            if (contextData != null)
            {
                return contextData.IsInRole(role);
            }
            return false;
        }

        public void Dispose()
        {
            Debug.WriteLine("CT Principal Disposed");
        }

        private readonly WeakReference<UserContextData> _context;
        private static readonly IIdentity EmptyIdentity = new GenericIdentity(String.Empty);
        private static readonly IPrincipal EmptyPrincipal = new GenericPrincipal(new GenericIdentity(String.Empty), new string[0]);
    }
}