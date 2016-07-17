using System;

namespace SR.Core.UserManagement
{
    [Serializable]
    public class UserManagementException : TvException
    {
        public UserManagementException(string message)
            : base(message)
        {
        }
    }
}