using System;

namespace SR.ModelImpl.DbModel
{
    public class DbContactPerson
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
    }
}