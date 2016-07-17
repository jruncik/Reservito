using System;
using System.Diagnostics;
using System.Security.Principal;
using NHibernate;
using NHibernate.Stat;
using TV.Core.Rights;
using TV.Core.Users;

namespace TV.Core.Context
{
    public class UserContextData : IPrincipal, IIdentity
    {
        public UserContextData(SessionId sessionId, IUser currentUser, IRights rights)
        {
            _currentUser = currentUser;
            _sessionId = sessionId;
            _rights = rights;
            _sessionFactory = AppliactionContext.Configuartion.BuildSessionFactory();
            IsAuthenticated = true;
        }

        public IUser User
        {
            get { return _currentUser; }
        }

        public IRights Rights
        {
            get { return _rights; }
        }

        public SessionId SessionId
        {
            get { return _sessionId; }
        }

        public bool IsInRole(string role)
        {
            return _rights.IsInRole(role);
        }

        public bool IsInRole(Roles role)
        {
            return _rights.IsInRole(role);
        }

        public IIdentity Identity
        {
            get { return this; }
        }

        public string Name
        {
            get { return _currentUser.Username; }
        }

        public string AuthenticationType
        {
            get
            {
                Debug.Fail("Not implemented");
                return String.Empty;
            }
        }

        public ISessionFactory SessionFactory
        {
            get { return _sessionFactory; }
        }

        public bool IsAuthenticated { get; set; }

        public void Logout()
        {
            Debug.Assert(_originalPrincipal == null, "Context has to be detached from thread");

            _sessionFactory.Close();
            _sessionFactory.Dispose();

            _sessionId = SessionId.Empty;
            IsAuthenticated = false;
            _originalPrincipal = null;
            _currentUser = null;
            _rights = null;
        }

        public IPrincipal OriginalPrincipal
        {
            get { return _originalPrincipal; }
            set { _originalPrincipal = value; }
        }

        private IUser _currentUser;
        private IRights _rights;
        private SessionId _sessionId;
        private IPrincipal _originalPrincipal;
        private ISessionFactory _sessionFactory;
    }
}