using System;
using SR.Core;

namespace SR.CoreImpl.Autentication
{
    [Serializable]
    public class AutenticationException : TvException
    {
        public AutenticationException(string message)
            : base(message)
        {
        }
    }
}