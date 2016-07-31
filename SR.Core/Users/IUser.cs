using System;

namespace SR.Core.Users
{
    public interface IUser : IDbStorable
    {
        Guid Id { get; set; }

        string Username { get; set; }
        string Password { get; set; }

        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string PhoneNumber { get; set; }

        bool Active { get; set; }

        bool IsBuiltIn { get; }
    }
}