using NHibernate;

using SR.Core.DbAccess;

namespace SR.ModelImpl.DbAccess
{
    public class DbOperationsFactory : IDbOperationsFactory
    {
        public DbOperationsFactory(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public IDbOperations CreateDbOperations()
        {
            return new DbOperationsShortTimeSession(_sessionFactory);
        }

        private readonly ISessionFactory _sessionFactory;
    }
}
