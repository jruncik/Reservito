using System;
using System.Collections.Generic;
using SR.Core.Users;

namespace SR.Core.UserManagement
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