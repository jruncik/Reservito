using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NHibernate;
using TV.Core.Context;
using TV.Core.Rights;
using TV.Core.UserManagement;
using TV.Core.Users;
using TV.CoreImpl.Users;
using TV.ModelImpl.DbModel;

namespace TV.CoreImpl.UserManagement
{
    internal class UserManagement : IUserManagement
    {
        public UserManagement()
        {
            InitializeBuildInUsers();
            ReadAllUsers();
        }

        public IUser CreateNewUser(string username, string password)
        {
            CheckRights();

            if (String.IsNullOrEmpty(username))
            {
                AppliactionContext.Log.Warning(this, "Username is empty.");
                throw new UserManagementException(Resources.UsernameCantBeEmpty);
            }

            if (IsMaster(username) || IsGuest(username))
            {
                AppliactionContext.Log.Warning(this, String.Format("User with username '{0}' already exist.", username));
                throw new UserManagementException(String.Format(Resources.UserAlreadyExists, username));
            }

            if (String.IsNullOrEmpty(password))
            {
                AppliactionContext.Log.Warning(this, String.Format("Password for user '{0}' is empty.", username));
                throw new UserManagementException(Resources.PasswordCantBeEmpty);
            }

            using (ISession session = AppliactionContext.SessionFactory.OpenSession())
            {
                IQuery query = session.CreateQuery("from " + typeof (DbUser) + " u where u.Username = :Username");
                IList<DbUser> users = query.SetParameter("Username", username).List<DbUser>();

                if (users.Count != 0)
                {
                    AppliactionContext.Log.Warning(this, String.Format("User with username '{0}' already exist.", username));
                    throw new UserManagementException(String.Format(Resources.UserAlreadyExists, username));
                }
            }

            IUser newUser = new User(username, password);
            AppliactionContext.Log.Debug(this, String.Format("User with username '{0}' was created.", username));
            newUser.Save();
            _users.Add(newUser);

            return newUser;
        }

        public IUser TryFindUser(string username)
        {
            return _users.Where(user => String.Compare(username, user.Username, StringComparison.OrdinalIgnoreCase) == 0).DefaultIfEmpty(EmptyUser).First();
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
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    IList<DbUser> dbUsers = session.CreateCriteria<DbUser>().List<DbUser>();
                    foreach (DbUser dbUser in dbUsers)
                    {
                        IUser newUser = new User(dbUser);
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

        private readonly IList<IUser> _users = new List<IUser>();
        private readonly IUser MasterUser = new MasterUser();
        private readonly IUser GuestUser = new GuestUser();
        private readonly IUser EmptyUser = new EmptyUser();
    }
}