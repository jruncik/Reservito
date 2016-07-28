using System;
using System.Collections.Generic;

namespace SR.Core.DbAccess
{
    public interface IDbOperations
    {
        void Save(object dbObject);
        T Reload<T>(Guid id) where T : ICloneable;
        void Delete(object dbObject);

        IList<T> QueryDb<T>(string query, QueryParams queryParams);
        IList<T> GetAll<T>() where T : class;
    }
}
