using System;
using TV.Core;

namespace TV.CoreImpl.Autentication
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