using NHibernate;
using NHibernate.Cfg;

using SR.Core;
using SR.Core.Context;
using SR.Core.DbAccess;
using SR.Core.Log;
using SR.Core.UserManagement;
using SR.CoreImpl;
using SR.CoreImpl.Log;
using SR.Model;
using SR.ModelImpl.DbAccess;
using SR.ModelImpl.Model;

namespace SR.Reservito
{
    public class ReservitoApp : ContextSingleton<ReservitoApp>
    {
        public ReservitoApp()
        {
            InitApplicationContext();
            InitUserContext();
        }

        private static void InitApplicationContext()
        {
            ILog log = new Log();

            Configuration configuartion = new Configuration();
            configuartion.Configure();

            ISessionFactory sessionFactory = configuartion.BuildSessionFactory();

            ICoreFactory coreFactory = new CoreFactory();
            IDbOperationsFactory dbOperationsFactory = new DbOperationsFactory(sessionFactory);
            IDbModelObjectFactory modelObjectFactory = new DbModelObjectFactory();

            new AppliactionContext(log, coreFactory, dbOperationsFactory, modelObjectFactory);
        }

        private static void InitUserContext()
        {
            new UserContext();
        }
    }
}
