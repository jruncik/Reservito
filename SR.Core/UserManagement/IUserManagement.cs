using System.Collections.Generic;
using SR.Core.Users;
using System;

namespace SR.Core.UserManagement
{
    public interface IUserManagement
    {
        IUser CreateNewUser(string username, string password, string firstName, string lastName, string email, string phoneNumber);

        IUser TryFindUserById(Guid userId);
        IUser TryFindUserByUsername(string username);
        IUser TryFindUserByEmail(string email);
        IUser TryFindUserByFullName(string firstName, string lastName);

        void DeleteUser(IUser userToDelete);

        IList<IUser> Users { get; }

        void DeleteAllUsers();
    }
}