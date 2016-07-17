using System;
using SR.Core;

namespace SR.Model
{
    public interface IContactPerson : IDbStorable
    {
        Guid Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
    }
}