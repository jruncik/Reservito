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

        public bool Active
        {
            get { return false; }
            set { }
        }

        public bool IsBuiltIn
        {
            get { return true; }
        }

        public string FirstName
        {
            get { return String.Empty; }
            set { }
        }

        public string LastName
        {
            get { return String.Empty; }
            set { }
        }

        public string Email
        {
            get { return String.Empty; }
            set { }
        }

        public string PhoneNumber
        {
            get { return String.Empty; }
            set { }
        }

        public void Save()
        {
        }

        public void Load()
        {
        }

        public void Delete()
        {
        }

        public T GetDbObject<T>() where T : class
        {
            return (T)(object)null;
        }

    }
}