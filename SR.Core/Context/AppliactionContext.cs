using NHibernate;
using NHibernate.Cfg;
using SR.Core.Log;

namespace SR.Core.Context
{
    public class AppliactionContext : ContextSingleton<AppliactionContext>
    {
        public static ILog Log
        {
            get { return Instance._log; }
        }

        public static Configuration Configuartion
        {
            get { return Instance._configuartion; }
        }

        public static ISessionFactory SessionFactory
        {
            get { return Instance._sessionFactory; }
        }

        public AppliactionContext(ILog log, Configuration configuartion)
        {
            _log = log;
            _configuartion = configuartion;
            _sessionFactory = _configuartion.BuildSessionFactory();
        }

        private readonly ILog _log;
        private Configuration _configuartion;
        private ISessionFactory _sessionFactory;
    }
}