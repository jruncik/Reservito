using System;
using SR.Core;
using SR.Core.Context;
using SR.Core.Users;
using SR.ModelImpl.DbModel;

namespace SR.CoreImpl.Users
{
    internal class User : IUser
    {
        public User() :
            this(new DbUser())
        {
        }

        public User(DbUser dbUser)
        {
            _dbUser = dbUser;
        }

        public User(string username, string password, string firstName, string lastName, string email, string phoneNumber) :
            this(new DbUser())
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) ||
                String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName) || String.IsNullOrEmpty(email))
            {
                AppliactionContext.Log.Debug(this, "Username or password or FirstName or LastName or Email is empty.");
                throw new TvException(Resources.UsernameOrPasswordIsEmpty);
            }

            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public Guid Id
        {
            get { return _dbUser.Id; }
            set { _dbUser.Id = value; }
        }

        public string Username
        {
            get { return _dbUser.Username; }
            set { _dbUser.Username = value; }
        }

        public string Password
        {
            get { return _dbUser.Password; }
            set { _dbUser.Password = value; }
        }

        public string FirstName
        {
            get { return _dbUser.FirstName; }
            set { _dbUser.FirstName = value; }
        }

        public string LastName
        {
            get { return _dbUser.LastName; }
            set { _dbUser.LastName = value; }
        }

        public string Email
        {
            get { return _dbUser.Email; }
            set { _dbUser.Email = value; }
        }

        public string PhoneNumber
        {
            get { return _dbUser.PhoneNumber; }
            set { _dbUser.PhoneNumber = value; }
        }

        public bool Active
        {
            get { return _dbUser.Active; }
            set { _dbUser.Active = value; }
        }

        internal DbUser DbUser
        {
            get { return _dbUser; }
        }

        public bool IsBuiltIn
        {
            get { return false; }
        }

        public void Save()
        {
            using (AppliactionContext.Log.LogTime(this, $"Save user '{Username}'."))
            {
                AppliactionContext.DbOperations.Save(_dbUser);
            }
        }

        public void Reload()
        {
            using (AppliactionContext.Log.LogTime(this, $"Reload user '{Username}'."))
            {
                DbUser reloadedUser = AppliactionContext.DbOperations.Reload<DbUser>(_dbUser.Id);

                _dbUser.Password = reloadedUser.Password;
                _dbUser.Username = reloadedUser.Username;
            }
        }

        public void Delete()
        {
            using (AppliactionContext.Log.LogTime(this, $"Delete user '{Username}'."))
            {
                AppliactionContext.DbOperations.Delete(_dbUser);
            }
        }

        private readonly DbUser _dbUser;
    }
}