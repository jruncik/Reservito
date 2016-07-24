using SR.Core.DbAccess;
using SR.Core.Log;

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

        public AppliactionContext(ILog log, IDbOperationsFactory dbOperationsFactory)
        {
            _log = log;

            _dbOperationsFactory = dbOperationsFactory;

            _dbOperations = _dbOperationsFactory.CreateDbOperations();
        }

        private readonly ILog _log;
        private readonly IDbOperations _dbOperations;
        private readonly IDbOperationsFactory _dbOperationsFactory;
    }
}