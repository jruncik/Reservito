using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Security.Principal;
using System.Threading;
using System.Web;
using NHibernate;
using TV.Core.Rights;
using TV.Core.Users;

namespace TV.Core.Context
{
    public class UserContext : ContextSingleton<UserContext>
    {
        public static void Login(SessionId sessionId, IUser user, IRights rights)
        {
            if (sessionId.IsEmpty)
            {
                sessionId = SessionId.New;
            }

            Instance.CreateContext(new UserContextData(sessionId, user, rights));
        }

        public static void Logout()
        {
            Instance.CloseContext(SessionId);
        }

        public static void SetupThreadContext(SessionId id)
        {
            Instance.AttachThreadExecutionContext(id);
        }

        public static void CleanupThreadContext(SessionId id)
        {
            Instance.DetachThreadExecutionContext(id);
        }

        public static IUser User
        {
            get
            {
                UserContextData context = Instance.ContextData;
                if (context == null)
                {
                    AppliactionContext.Log.Error(null, "Calling user context functionality without any logged user.");
                    return null;
                }
                return context.User;
            }
        }

        public static ISessionFactory SessionFactory
        {
            get
            {
                UserContextData context = Instance.ContextData;
                if (context == null)
                {
                    AppliactionContext.Log.Error(null, "Calling user context functionality without any logged user.");
                    return null;
                }
                return context.SessionFactory;
            }
        }

        public static SessionId SessionId
        {
            get
            {
                UserContextData context = Instance.ContextData;
                if (context == null)
                {
                    // AppliactionContext.Log.Error(null, "Calling user context functionality without any logged user.");
                    return SessionId.Empty;
                }
                return context.SessionId;
            }
        }

        public static UserContextData Context
        {
            get
            {
                UserContextData context = Instance.ContextData;
                if (context == null)
                {
                    AppliactionContext.Log.Error(null, "Calling user context functionality without any logged user.");
                    return null;
                }
                return context;
            }
        }

        private void CreateContext(UserContextData contextData)
        {
            if (contextData.SessionId.IsEmpty)
            {
                AppliactionContext.Log.Error(this, String.Format("Can't create context for user '{0}' with sessiosId '{1}'.", User.Username, SessionId));
                return;
            }

            if (!_contexts.ContainsKey(contextData.SessionId))
            {
                AppliactionContext.Log.Debug(this, String.Format("Creating context for user '{0}' with sessiosId '{1}'.", contextData.User.Username, contextData.SessionId));
                while (!_contexts.TryAdd(contextData.SessionId, contextData))
                { }
                InitializeContextData(contextData);
                AttachThreadExecutionContext(contextData.SessionId);
            }
            AppliactionContext.Log.Debug(this, String.Format("Context was created for user '{0}' with sessiosId '{1}'.", User.Username, SessionId));
        }

        private void InitializeContextData(UserContextData contextData)
        {
        }

        private void CloseContext(SessionId sessionId)
        {
            if (sessionId.IsEmpty)
            {
                return;
            }

            if (_contexts.ContainsKey(sessionId))
            {
                AppliactionContext.Log.Debug(this, String.Format("Closing context for user '{0}' with sessiosId '{1}'.", User.Username, SessionId));
                UserContextData contextData;

                DetachThreadExecutionContext(sessionId);

                while (!_contexts.TryRemove(sessionId, out contextData))
                { }
                ClosseContextData(contextData);
            }
            AppliactionContext.Log.Debug(this, "Context closed.");
        }

        private void ClosseContextData(UserContextData contextData)
        {
            contextData.Logout();
        }

        private void AttachThreadExecutionContext(SessionId id)
        {
            SetupThreadContext(GetUserContextData(id), id);
        }

        private void SetupThreadContext(UserContextData contextData, SessionId id)
        {
            if (contextData == null)
            {
                return;
            }

            IPrincipal principal = TryGetPrincipal();

            if (principal != null)
            {
                if (!(principal is GenericPrincipal))
                {
                    // Debug.Fail("It has to be the same principal!");
                }
                contextData.OriginalPrincipal = principal;
            }

            principal = new UserContextPrincipal(contextData);

            SetPrincipal(principal);

            AppliactionContext.Log.Debug(this, String.Format("User '{0}' with sessionId '{1}' was attached to the thread.", User.Username, SessionId));

            if (ExecutionContext.IsFlowSuppressed())
            {
                ExecutionContext.RestoreFlow();
            }
        }

        private void DetachThreadExecutionContext(SessionId id)
        {
            UserContextData contextData = Instance.ContextData;
            if (contextData == null)
            {
                return;
            }

            if (contextData.SessionId != id)
            {
                AppliactionContext.Log.Error(this, String.Format("Different sessionId '{0}'. Context sessionId sessiosId '{1}'.", id, contextData.SessionId));
            }

            UserContextPrincipal principal = TryGetUserContextPrincipal();
            if (principal != null)
            {
                AppliactionContext.Log.Debug(this, String.Format("Detaching user '{0}' with sessiosId '{1}' from the thread.", User.Username, SessionId));
                SetPrincipal(contextData.OriginalPrincipal);
                contextData.OriginalPrincipal = null;
            }
        }

        private UserContextData ContextData
        {
            get { return GetCurrentContextData(); }
        }

        private UserContextData GetCurrentContextData()
        {
            UserContextPrincipal principal = TryGetUserContextPrincipal();
            if (principal == null)
            {
                return null;
            }

            if (principal.Context == null)
            {
                return null;
            }

            return principal.Context;
        }

        private UserContextData GetUserContextData(SessionId id)
        {
            if (!_contexts.ContainsKey(id))
            {
                return null;
            }

            UserContextData context;
            while (!_contexts.TryGetValue(id, out context))
            { }

            return context;
        }

        private static IPrincipal TryGetPrincipal()
        {
            IPrincipal principal = Thread.CurrentPrincipal;
            if (principal == null)
            {
                principal = HttpContext.Current.User;
            }

            return principal;
        }

        private static UserContextPrincipal TryGetUserContextPrincipal()
        {
            UserContextPrincipal principal = Thread.CurrentPrincipal as UserContextPrincipal;
            if (principal == null)
            {
                if (HttpContext.Current != null)
                {
                    principal = HttpContext.Current.User as UserContextPrincipal;
                }
            }

            return principal;
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        private ConcurrentDictionary<SessionId, UserContextData> _contexts = new ConcurrentDictionary<SessionId, UserContextData>();
    }
}