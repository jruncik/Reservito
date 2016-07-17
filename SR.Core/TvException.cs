using System;

namespace SR.Core
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