using System;
using System.Collections.Generic;

using SR.Core;
using SR.Core.Context;
using SR.Core.DbAccess;
using SR.Core.Rights;
using SR.Core.UserManagement;
using SR.Core.Users;
using SR.CoreImpl.Users;

using SR.ModelImpl.DbModel;

namespace SR.CoreImpl.Autentication
{
    internal class Autentication : IAutentication
    {
        public Autentication(IUserManagement userManagement)
        {
            _userManagement = userManagement;
        }

        public void LogIn(string username, String password)
        {
            LogIn(SessionId.New, username, password);
        }

        public void LogIn(SessionId sessionId, String username, String password)
        {
            try
            {
                IUser user = GetUser(username, password);
                IRights rights = GetRights(user);

                if (UserContext.SessionId != SessionId.Empty)
                {
                    UserContext.Logout();
                }

                UserContext.Login(sessionId, user, rights);
            }
            catch (Exception)
            {
                UserContext.Logout();
                throw;
            }
        }

        private IUser GetUser(string username, string password)
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                AppliactionContext.Log.Warning(this, "Username or password is empty.");
                throw new AutenticationException(Resources.UsernameOrPasswordIsEmpty);
            }

            IUser user = _userManagement.TryFindUserByUsername(username);
            if (user == null)
            {
                AppliactionContext.Log.Warning(this, "Username is unknown.");
                throw new AutenticationException(String.Format(Resources.UsernameUnknow, username));
            }

            if (user.Password != password)
            {
                AppliactionContext.Log.Warning(this, "Password doesn't match.");
                throw new AutenticationException(Resources.WrongPassword);
            }

            AppliactionContext.Log.Info(this, string.Format("User '{0}' is sucessfully loged in.", username));
            return user;
        }

        private IRights GetRights(IUser user)
        {
            if (user == null)
            {
                AppliactionContext.Log.Error(this, "Can't read rights for nulluser");
                return Rights.Rights.Empty;
            }

            if (user is MasterUser)
            {
                AppliactionContext.Log.Debug(this, string.Format("Master rights assigned for user '{0}'.", user.Username));
                return Rights.Rights.Master;
            }

            if (user is GuestUser)
            {
                AppliactionContext.Log.Debug(this, string.Format("Guest rights assigned for user '{0}'.", user.Username));
                return Rights.Rights.Guest;
            }

            string query = "from " + typeof(DbRights) + " r where r.FkUser = :UserId";
            QueryParams queryParams = new QueryParams(new QueryParam("UserId", user.Id));

            IList<DbRights> userRights = AppliactionContext.DbOperations.QueryDb<DbRights>(query, queryParams);

            if (userRights.Count != 1)
            {
                AppliactionContext.Log.Error(this, String.Format("Rights for User '{0}' wasn't found.", user.Username));
                return Rights.Rights.Empty;
            }

            return new Rights.Rights((Roles)userRights[0].Rights);
        }

        private readonly IUserManagement _userManagement;
    }
}