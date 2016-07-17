using System;
using NHibernate;
using SR.Core;
using SR.Core.Context;
using SR.Core.Users;
using SR.ModelImpl.DbModel;

namespace SR.CoreImpl.Users
{
    internal class User : IUser
    {
        public User() :
            this(new DbUser())
        {
        }

        public User(DbUser dbUser)
        {
            _dbUser = dbUser;
        }

        public User(String username, String password) :
            this(new DbUser())
        {
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                AppliactionContext.Log.Debug(this, "Username or password is empty.");
                throw new TvException(Resources.UsernameOrPasswordIsEmpty);
            }

            Username = username;
            Password = password;
        }

        public Guid Id
        {
            get { return _dbUser.Id; }
            set { _dbUser.Id = value; }
        }

        public string Username
        {
            get { return _dbUser.Username; }
            set { _dbUser.Username = value; }
        }

        public string Password
        {
            get { return _dbUser.Password; }
            set { _dbUser.Password = value; }
        }

        internal DbUser DbUser
        {
            get { return _dbUser; }
        }

        public bool IsBuiltIn
        {
            get
            {
                return false;
            }
        }

        public void Save()
        {
            using (AppliactionContext.Log.LogTime(this, String.Format("Save user '{0}'.", Username)))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        try
                        {
                            if (Id == Guid.Empty)
                            {
                                session.Save(_dbUser);
                            }
                            else
                            {
                                session.Update(_dbUser);
                            }
                            tx.Commit();
                        }
                        catch (Exception ex)
                        {
                            AppliactionContext.Log.Critical(this, ex.Message);
                            tx.Rollback();
                            throw ex;
                        }
                    }
                }
            }
        }

        public void Reload()
        {
            using (AppliactionContext.Log.LogTime(this, String.Format("Reload user '{0}'.", Username)))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        try
                        {
                            DbUser reloadedUser = session.Load<DbUser>(_dbUser.Id);

                            _dbUser.Password = reloadedUser.Password;
                            _dbUser.Username = reloadedUser.Username;
                        }
                        catch (Exception ex)
                        {
                            AppliactionContext.Log.Critical(this, ex.Message);
                            tx.Rollback();
                            throw ex;
                        }
                    }
                }
            }
        }

        public void Delete()
        {
            using (AppliactionContext.Log.LogTime(this, String.Format("Delete user '{0}'.", Username)))
            {
                using (ISession session = AppliactionContext.SessionFactory.OpenSession())
                {
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        try
                        {
                            session.Delete(_dbUser);
                            tx.Commit();
                        }
                        catch (Exception ex)
                        {
                            AppliactionContext.Log.Critical(this, ex.Message);
                            tx.Rollback();
                            throw ex;
                        }
                    }
                }
            }
        }

        private readonly DbUser _dbUser;
    }
}