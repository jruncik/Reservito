using System;

using SR.Core;
using SR.Core.Context;
using SR.Core.Users;
using SR.ModelImpl;

namespace SR.ModelImpl.Model
{
    public class User : IUser, IDbCloneable
    {
        public User()
        {
            Id = Guid.Empty;

            Username = String.Empty;
            Password = String.Empty;
            FirstName = String.Empty;
            LastName = String.Empty;
            PhoneNumber = String.Empty;
            Email = String.Empty;
            Active = false;
        }

        public User(User other)
        {
            Id = other.Id;
            Username = other.Username;
            Password = other.Password;
            FirstName = other.FirstName;
            LastName = other.LastName;
            PhoneNumber = other.PhoneNumber;
            Email = other.Email;
            Active = other.Active;
        }

        public User(string username, string password, string firstName, string lastName, string email, string phoneNumber)
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

        public virtual Guid Id { get; set; }

        public virtual string Username { get; set; }
        public virtual string Password { get; set; }

        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Email { get; set; }
        public virtual bool Active { get; set; }

        public virtual bool IsBuiltIn
        {
            get { return false; }
        }

        public virtual void Save()
        {
            using (AppliactionContext.Log.LogTime(this, $"Save user '{Username}'."))
            {
                AppliactionContext.DbOperations.Save(this);
            }
        }

        public virtual void Load()
        {
            using (AppliactionContext.Log.LogTime(this, $"Reload user '{Username}'."))
            {
                User reloadedUser = AppliactionContext.DbOperations.Load<User>(Id);

                Password = reloadedUser.Password;
                Username = reloadedUser.Username;
            }
        }

        public virtual void Delete()
        {
            using (AppliactionContext.Log.LogTime(this, $"Delete user '{Username}'."))
            {
                AppliactionContext.DbOperations.Delete(this);
            }
        }

        public virtual T GetDbObject<T>() where T : class
        {
            return (T)(object)this;
        }

        public virtual T Clone<T>() where T : class
        {
            return (T)(object)(new User(this));
        }
    }
}