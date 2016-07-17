using System;

namespace TV.Core
{
    [Serializable]
    public class TvException : Exception
    {
        public TvException(string message)
            : base(message)
        {
        }
    }
}