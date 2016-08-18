using SR.Core.DbAccess;
using SR.Core.Log;
using SR.Core.UserManagement;

namespace SR.Core.Context
{
    public class AppliactionContext : ContextSingleton<AppliactionContext>
    {
        public static ILog Log
        {
            get { return Instance._log; }
        }

        public static IDbOperations DbOperations
        {
            get { return Instance._dbOperations; }
        }

        public static IDbOperationsFactory DbOperationsFactory
        {
            get { return Instance._dbOperationsFactory; }
        }

        public static IAutentication Autentication
        {
            get { return Instance._autentication; }
        }

        public static IUserManagement UserManagement
        {
            get { return Instance._userManagement; }
        }

        public static T GetModelObjectFactory<T>()
        {
            return (T)Instance._objectModelFactory;
        }

        public AppliactionContext(ILog log, ICoreFactory coreFactory, IDbOperationsFactory dbOperationsFactory, object objectModelFactory)
        {
            _log = log;
            _coreFactory = coreFactory;
            _dbOperationsFactory = dbOperationsFactory;
            _objectModelFactory = objectModelFactory;

            _dbOperations = _dbOperationsFactory.CreateDbOperations();

            _userManagement = _coreFactory.CreateUserManagement();
            _autentication = _coreFactory.CreateAutentication(_userManagement);
        }

        private readonly ICoreFactory _coreFactory;
        private readonly ILog _log;
        private readonly IDbOperations _dbOperations;
        private readonly IDbOperationsFactory _dbOperationsFactory;
        private readonly IAutentication _autentication;
        private readonly IUserManagement _userManagement;
        private readonly object _objectModelFactory;

    }
}