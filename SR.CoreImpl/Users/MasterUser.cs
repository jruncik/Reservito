using System;
using SR.Core.Users;

namespace SR.CoreImpl.Users
{
    internal class MasterUser : IUser
    {
        public Guid Id
        {
            get { return Guid.Empty; }
            set { }
        }

        public string Username
        {
            get { return MASTER_USERNAME; }
            set { }
        }

        public string Password
        {
            get { return MASTER_PASSWORD; }
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

        private const String MASTER_USERNAME = "remaster";
        private const String MASTER_PASSWORD = "rmaster";
    }
}