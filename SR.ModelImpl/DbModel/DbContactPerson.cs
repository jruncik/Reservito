using System;

namespace SR.ModelImpl.DbModel
{
    public class DbContactPerson : ICloneable
    {
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string Email { get; set; }

        public DbContactPerson()
        {
            Id = Guid.Empty;
            FirstName = String.Empty;
            LastName = String.Empty;
            PhoneNumber = String.Empty;
            Email = String.Empty;
        }

        public DbContactPerson(DbContactPerson other)
        {
            Id = other.Id;
            FirstName = other.FirstName;
            LastName = other.LastName;
            PhoneNumber = other.PhoneNumber;
            Email = other.Email;
        }

        public virtual object Clone()
        {
            return new DbContactPerson(this);
        }


    }
}