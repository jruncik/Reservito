using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using SR.Core.Context;
using SR.Core.DbAccess;
using SR.Core.Rights;
using SR.Core.UserManagement;
using SR.Core.Users;
using SR.CoreImpl.Users;

using SR.Model;
using SR.ModelImpl.Model;

namespace SR.CoreImpl.UserManagement
{
    internal class UserManagement : IUserManagement
    {
        public UserManagement()
        {
            InitializeBuildInUsers();
            ReadAllUsers();
        }

        public IUser CreateNewUser(string username, string password, string firstName, string lastName, string email, string phoneNumber)
        {
            CheckRights();

            if (String.IsNullOrEmpty(username))
            {
                AppliactionContext.Log.Warning(this, "Username is empty.");
                throw new UserManagementException(Resources.UsernameCantBeEmpty);
            }

            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) ||
                String.IsNullOrEmpty(firstName) || String.IsNullOrEmpty(lastName) || String.IsNullOrEmpty(email))
            {
                AppliactionContext.Log.Debug(this, "Username or password or FirstName or LastName or Email is empty.");
                throw new UserManagementException(Resources.UsernameOrPasswordIsEmpty);
            }

            if (IsMaster(username) || IsGuest(username))
            {
                AppliactionContext.Log.Warning(this, $"User with username '{username}' already exist.");
                throw new UserManagementException(String.Format(Resources.UserAlreadyExists, username));
            }

            if (String.IsNullOrEmpty(password))
            {
                AppliactionContext.Log.Warning(this, $"Password for user '{username}' is empty.");
                throw new UserManagementException(Resources.PasswordCantBeEmpty);
            }

            string query = "from " + typeof(User) + " u where u.Username = :Username";
            QueryParams queryParams = new QueryParams(new QueryParam("Username", username));

            IList<User> users = AppliactionContext.DbOperations.QueryDb<User>(query, queryParams);

            if (users.Count != 0)
            {
                AppliactionContext.Log.Warning(this, $"User with username '{username}' already exist.");
                throw new UserManagementException(String.Format(Resources.UserAlreadyExists, username));
            }

            IDbModelObjectFactory modelFactory = AppliactionContext.GetModelObjectFactory<IDbModelObjectFactory>();
            IUser newUser = modelFactory.CreateUser(username, password, firstName, lastName, email, phoneNumber);
            AppliactionContext.Log.Debug(this, $"User with username '{username}' was created.");
            newUser.Save();

            _users.Add(newUser);

            return newUser;
        }

        public IUser TryFindUserById(Guid userId)
        {
            return _users.Where(user => userId == user.Id).DefaultIfEmpty(EmptyUser).First();
        }

        public IUser TryFindUserByUsername(string username)
        {
            return _users.Where(user => String.Compare(username, user.Username, StringComparison.OrdinalIgnoreCase) == 0).DefaultIfEmpty(EmptyUser).First();
        }

        public IUser TryFindUserByEmail(string email)
        {
            return _users.Where(user => String.Compare(email, user.Email, StringComparison.OrdinalIgnoreCase) == 0).DefaultIfEmpty(EmptyUser).First();
        }

        public IUser TryFindUserByFullName(string firstName, string lastName)
        {
            return _users.Where(user => String.Compare(firstName, user.FirstName, StringComparison.OrdinalIgnoreCase) == 0 &&
                                        String.Compare(lastName, user.LastName, StringComparison.OrdinalIgnoreCase) == 0).DefaultIfEmpty(EmptyUser).First();
        }

        public void DeleteUser(IUser userToDelete)
        {
            lock (_lock)
            {
                CheckRights();

                if (!userToDelete.IsBuiltIn)
                {
                    _users.Remove(userToDelete);
                    userToDelete.Delete();
                }
            }
        }

        public void DeleteAllUsers()
        {
            lock (_lock)
            {
                IEnumerable<IUser> usersToDelete = _users.Where(user => !user.IsBuiltIn);

                foreach (IUser userToDelete in usersToDelete)
                {
                    userToDelete.Delete();
                }

                _users.Clear();
                InitializeBuildInUsers();
            }
        }

        public IList<IUser> Users
        {
            get { return _users; }
        }

        private void InitializeBuildInUsers()
        {
            Debug.Assert(_users.Count == 0);
            _users.Add(GuestUser);
            _users.Add(MasterUser);
        }

        private void ReadAllUsers()
        {
            lock (_lock)
            {
                using (AppliactionContext.Log.LogTime(this, "Reading all users"))
                {
                    IList<User> users = AppliactionContext.DbOperations.GetAll<User>();
                    foreach (User user in users)
                    {
                        IUser newUser = new User(user);
                        _users.Add(newUser);
                        AppliactionContext.Log.Debug(this, String.Format("User '{0}' read from DB.", newUser.Username));
                    }
                }
            }
        }

        private bool IsMaster(String username)
        {
            return String.Compare(username, MasterUser.Username, StringComparison.OrdinalIgnoreCase) == 0;
        }

        private bool IsGuest(String username)
        {
            return String.Compare(username, GuestUser.Username, StringComparison.OrdinalIgnoreCase) == 0;
        }

        private void CheckRights()
        {
            if (!UserContext.Context.IsInRole(Roles.ManageUsers))
            {
                throw new RightsException(String.Format(Resources.NotEnoughtRights, UserContext.User.Username));
            }
        }

        private readonly object _lock = new object();
        private readonly IList<IUser> _users = new List<IUser>();
        private readonly IUser MasterUser = new MasterUser();
        private readonly IUser GuestUser = new GuestUser();
        private readonly IUser EmptyUser = new EmptyUser();

    }
}