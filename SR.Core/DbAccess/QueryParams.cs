using System.Collections;
using System.Collections.Generic;

namespace SR.Core.DbAccess
{
    public class QueryParams : IEnumerable<QueryParam>
    {
        public QueryParams()
        {
        }

        public QueryParams(QueryParam queryParam)
        {
            AddQueryParam(queryParam);
        }

        public void AddQueryParam(QueryParam queryParam)
        {
            _queryParams.Add(queryParam);
        }

        public IEnumerator<QueryParam> GetEnumerator()
        {
            return _queryParams.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _queryParams.GetEnumerator();
        }

        private readonly List<QueryParam> _queryParams = new List<QueryParam>(4);
    }
}
