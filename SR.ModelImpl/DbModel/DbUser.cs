using System;

namespace TV.ModelImpl.DbModel
{
    public class DbUser
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
    }
}