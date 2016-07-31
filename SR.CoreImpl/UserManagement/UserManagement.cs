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

using SR.ModelImpl.DbModel;

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

            string query = "from " + typeof(DbUser) + " u where u.Username = :Username";
            QueryParams queryParams = new QueryParams(new QueryParam("Username", username));

            IList<DbUser> users = AppliactionContext.DbOperations.QueryDb<DbUser>(query, queryParams);

            if (users.Count != 0)
            {
                AppliactionContext.Log.Warning(this, $"User with username '{username}' already exist.");
                throw new UserManagementException(String.Format(Resources.UserAlreadyExists, username));
            }

            IUser newUser = new User(username, password, firstName, lastName, email, phoneNumber);
            AppliactionContext.Log.Debug(this, $"User with username '{username}' was created.");
            newUser.Save();

            _users.Add(newUser);

            return newUser;
        }

        public IUser TryFindUser(string username)
        {
            return _users.Where(user => String.Compare(username, user.Username, StringComparison.OrdinalIgnoreCase) == 0).DefaultIfEmpty(EmptyUser).First();
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
            CheckRights();

            if (!userToDelete.IsBuiltIn)
            {
                ((User)userToDelete).Delete();
                _users.Remove(userToDelete);
            }
        }

        public void DeleteAllUsers()
        {
            IEnumerable<IUser> usersToDelete = _users.Where(user => !user.IsBuiltIn);

            foreach (IUser userToDelete in usersToDelete)
            {
                ((User)userToDelete).Delete();
            }

            _users.Clear();
            InitializeBuildInUsers();
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
            using (AppliactionContext.Log.LogTime(this, "Reading all users"))
            {
                IList<DbUser> dbUsers = AppliactionContext.DbOperations.GetAll<DbUser>();
                foreach (DbUser dbUser in dbUsers)
                {
                    IUser newUser = new User(dbUser);
                    _users.Add(newUser);
                    AppliactionContext.Log.Debug(this, String.Format("User '{0}' read from DB.", newUser.Username));
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

        private readonly IList<IUser> _users = new List<IUser>();
        private readonly IUser MasterUser = new MasterUser();
        private readonly IUser GuestUser = new GuestUser();
        private readonly IUser EmptyUser = new EmptyUser();
    }
}