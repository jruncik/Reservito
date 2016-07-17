using System;
using System.Collections.Generic;
using TV.Core.Users;

namespace TV.Core.UserManagement
{
    public interface IUserManagement
    {
        IUser CreateNewUser(String username, String password);
        IUser TryFindUser(String username);
        void DeleteUser(IUser userToDelete);

        IList<IUser> Users { get; }

        void DeleteAllUsers();
    }
}