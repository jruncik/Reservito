using System;
using SR.Core.Users;

namespace SR.CoreImpl.Users
{
    internal class EmptyUser : IUser
    {
        public Guid Id
        {
            get { return Guid.Empty; }
            set { }
        }

        public string Username
        {
            get { return String.Empty; }
            set { }
        }

        public string Password
        {
            get { return String.Empty; }
            set { }
        }

        public bool IsBuiltIn
        {
            get
            {
                return true;
            }
        }

        public void Save()
        {
        }

        public void Reload()
        {
        }

        public void Delete()
        {
        }
    }
}