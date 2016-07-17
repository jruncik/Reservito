using System;

namespace SR.Core.Rights
{
    [Serializable]
    public class RightsException : TvException
    {
        public RightsException(string message)
            : base(message)
        {
        }
    }
}