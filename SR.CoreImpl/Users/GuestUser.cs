using System;
using SR.Core.Users;

namespace SR.CoreImpl.Users
{
    internal class GuestUser : IUser
    {
        public Guid Id
        {
            get { return Guid.Empty; }
            set { }
        }

        public string Username
        {
            get { return GUEST_USERNAME; }
            set { }
        }

        public string Password
        {
            get { return GUEST_PASSWORD; }
            set { }
        }

        public bool Active
        {
            get { return true; }
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

        public void Reload()
        {
        }

        public void Delete()
        {
        }

        private const string GUEST_USERNAME = "Guest";
        private const string GUEST_PASSWORD = "guest";
    }
}