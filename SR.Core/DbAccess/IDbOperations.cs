using System;
using System.Collections.Generic;

namespace SR.Core.DbAccess
{
    public interface IDbOperations : IDisposable
    {
        void Save(object dbObject);

        T Load<T>(Guid id) where T : class, IDbCloneable;

        void Delete(object dbObject);

        IList<T> QueryDb<T>(string query, QueryParams queryParams);

        IList<T> GetAll<T>() where T : class;
    }
}
