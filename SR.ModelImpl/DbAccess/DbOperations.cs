using System;
using System.Collections.Generic;

using NHibernate;

using SR.Core.Context;
using SR.Core.DbAccess;

namespace SR.ModelImpl.DbAccess
{
    internal class DbOperations : IDbOperations
    {
        internal DbOperations(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public void Save(object dbObject)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        session.SaveOrUpdate(dbObject);
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
        }

        public T Reload<T>(Guid id)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        return (T)session.Load<T>(id);
                    }
                    catch (Exception ex)
                    {
                        AppliactionContext.Log.Critical(this, ex.Message);
                        tx.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public void Delete(object dbObject)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(dbObject);
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
        }

        public IList<T> QueryDb<T>(string query, QueryParams queryParams)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                try
                {
                    IQuery nhQuery = session.CreateQuery(query);

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
        }

        public IList<T> GetAll<T>() where T: class
        {
            try
            {
                using (ISession session = _sessionFactory.OpenSession())
                {
                    return session.CreateCriteria<T>().List<T>();
                }
            }
            catch (Exception ex)
            {
                AppliactionContext.Log.Critical(this, ex.Message);
            }

            return new List<T>(0);
        }

        private readonly ISessionFactory _sessionFactory;
    }
}
