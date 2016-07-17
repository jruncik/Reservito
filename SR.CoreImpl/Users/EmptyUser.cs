using System;
using TV.Core.Users;

namespace TV.CoreImpl.Users
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