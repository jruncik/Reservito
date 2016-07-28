using System;

namespace SR.ModelImpl.DbModel
{
    public class DbUser : ICloneable
    {
        public virtual Guid Id { get; set; }
        public virtual String Username { get; set; }
        public virtual String Password { get; set; }

        public DbUser()
        {
            Id = Guid.Empty;
            Username = String.Empty;
            Password = String.Empty;
        }

        public DbUser(DbUser other)
        {
            Id = other.Id;
            Username = other.Username;
            Password = other.Password;
        }

        public virtual object Clone()
        {
            return new DbUser(this);
        }
    }
}