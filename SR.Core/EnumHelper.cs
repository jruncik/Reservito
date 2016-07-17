using System;
using System.Collections;
using System.Collections.Generic;

namespace SR.Core
{
    public class EnumHelper<T> : IEnumerable<T> where T : struct
    {
        static EnumHelper()
        {
            _strToEnum = new Dictionary<string, T>();
            foreach (string enumName in Enum.GetNames(typeof (T)))
            {
                _strToEnum.Add(enumName.ToLower(), (T) Enum.Parse(typeof (T), enumName));
            }

            _enumToStr = new Dictionary<T, string>();
            foreach (T item in Enum.GetValues(typeof (T)))
            {
                _enumToStr.Add(item, Enum.GetName(typeof(T), item));
            }
        }

        public static T FromString(string value)
        {
            string enumValue = value.ToLower();
            if (_strToEnum.ContainsKey(enumValue))
            {
                return _strToEnum[value.ToLower()];
            }

            return _defaultvalue;
        }

        public static string ToString(T value)
        {
            return _enumToStr[value];
        }

        public static T DefaultValue
        {
            get
            {
                return _defaultvalue;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in Enum.GetValues(typeof(T)))
            {
                // if (item != _defaultvalue)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private static readonly Dictionary<string, T> _strToEnum;
        private static readonly Dictionary<T, string> _enumToStr;
        protected static T _defaultvalue;
    }
}