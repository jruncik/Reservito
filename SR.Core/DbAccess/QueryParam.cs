﻿namespace SR.Core.DbAccess
{
    public class QueryParam
    {
        public QueryParam(string name, object value)
        {
            _name = name;
            _value = value;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public object Value
        {
            get
            {
                return _value;
            }
        }

        private readonly string _name;
        private readonly object _value;
    }
}
