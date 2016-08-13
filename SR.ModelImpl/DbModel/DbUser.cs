using System;
using SR.Core;

namespace SR.ModelImpl.DbModel
{
    public class DbUser : IDbCloneable
    {
        public virtual Guid Id { get; set; }

        public virtual string Username { get; set; }
        public virtual string Password { get; set; }

        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Email { get; set; }
        public virtual bool Active { get; set; }

        public DbUser()
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

        public DbUser(DbUser other)
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

        public virtual T Clone<T>() where T : class
        {
            return (T)(object)(new DbUser(this));
        }
    }
}