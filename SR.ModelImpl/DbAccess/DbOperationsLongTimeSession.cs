using System;
using System.Collections.Generic;

using NHibernate;

using SR.Core;
using SR.Core.Context;
using SR.Core.DbAccess;

namespace SR.ModelImpl.DbAccess
{
    internal class DbOperationsLongTimeSession : EasyDispose, IDbOperations
    {
        internal DbOperationsLongTimeSession(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
            _session = _sessionFactory.OpenSession();
        }

        protected override void DestroyManagedResources()
        {
            _session.Dispose();
            _session = null;

            _sessionFactory = null;
        }

        public void Save(object dbObject)
        {
            using (ITransaction tx = _session.BeginTransaction())
            {
                try
                {
                    _session.SaveOrUpdate(dbObject);
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    AppliactionContext.Log.Critical(this, ex.Message);
                    tx.Rollback();
                    throw ex;
                }
            }
        }

        public T Load<T>(Guid id) where T : ICloneable
        {
            using (ITransaction tx = _session.BeginTransaction())
            {
                try
                {
                    // Long time session doesn't need Clone(). Poroxy objects isn't deleted.
                    return (T)_session.Load<T>(id);
                }
                catch (Exception ex)
                {
                    AppliactionContext.Log.Critical(this, ex.Message);
                    tx.Rollback();
                    throw ex;
                }
            }
        }

        public void Delete(object dbObject)
        {
            using (ITransaction tx = _session.BeginTransaction())
            {
                try
                {
                    _session.Delete(dbObject);
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    AppliactionContext.Log.Critical(this, ex.Message);
                    tx.Rollback();
                    throw ex;
                }
            }
        }

        public IList<T> QueryDb<T>(string query, QueryParams queryParams)
        {
            try
            {
                IQuery nhQuery = _session.CreateQuery(query);

                foreach (QueryParam queryParam in queryParams)
                {
                    nhQuery.SetParameter(queryParam.Name, queryParam.Value);
                }

                return nhQuery.List<T>();
            }
            catch (Exception ex)
            {
                AppliactionContext.Log.Critical(this, ex.Message);
            }

            return new List<T>(0);
        }

        public IList<T> GetAll<T>() where T : class
        {
            try
            {
                return _session.CreateCriteria<T>().List<T>();
            }
            catch (Exception ex)
            {
                AppliactionContext.Log.Critical(this, ex.Message);
            }

            return new List<T>(0);
        }

        private ISessionFactory _sessionFactory;
        private ISession _session;
    }
}
