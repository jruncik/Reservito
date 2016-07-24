using NHibernate;
using NHibernate.Cfg;

using SR.Core;
using SR.Core.Context;
using SR.Core.DbAccess;
using SR.Core.Log;
using SR.Core.UserManagement;
using SR.CoreImpl;
using SR.CoreImpl.Log;
using SR.ModelImpl.DbAccess;

namespace SR.Reservito
{
    public class ReservitoApp : ContextSingleton<ReservitoApp>
    {
        public ReservitoApp()
        {
            InitApplicationContext();
            InitUserContext();

            _coreFactory = new CoreFactory();

            _userManagement = _coreFactory.CreateUserManagement();
            _autentication = _coreFactory.CreateAutentication(_userManagement);
        }

        private static void InitApplicationContext()
        {
            ILog log = new Log();

            Configuration configuartion = new Configuration();
            configuartion.Configure();

            ISessionFactory sessionFactory = configuartion.BuildSessionFactory();

            IDbOperationsFactory dbOperationsFactory = new DbOperationsFactory(sessionFactory);

            new AppliactionContext(log, dbOperationsFactory);
        }

        private static void InitUserContext()
        {
            new UserContext();
        }

        public static IAutentication Autentication
        {
            get { return Instance._autentication; }
        }

        public static IUserManagement UserManagement
        {
            get { return Instance._userManagement; }
        }

        private readonly ICoreFactory _coreFactory;
        private readonly IAutentication _autentication;
        private readonly IUserManagement _userManagement;
    }
}
