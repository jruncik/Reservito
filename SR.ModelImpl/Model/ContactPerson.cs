using System;
using NHibernate;
using SR.Core.Context;
using SR.Model;
using SR.ModelImpl.DbModel;

namespace SR.ModelImpl.Model
{
    public class ContactPerson : IContactPerson
    {
        public ContactPerson() :
            this(new DbContactPerson())
        {
        }

        public ContactPerson(DbContactPerson dbContactPerson)
        {
            _dbContactPerson = dbContactPerson;
        }

        public virtual Guid Id
        {
            get {
                return _dbContactPerson.Id;
            }
            set {
                _dbContactPerson.Id = value;
            }
        }

        public virtual string FirstName
        {
            get {
                return _dbContactPerson.FirstName;
            }
            set {
                _dbContactPerson.FirstName = value;
            }
        }

        public virtual string LastName
        {
            get {
                return _dbContactPerson.LastName;
            }
            set {
                _dbContactPerson.LastName = value;
            }

        }

        public virtual string PhoneNumber
        {
            get {
                return _dbContactPerson.PhoneNumber;
            }
            set {
                _dbContactPerson.PhoneNumber = value;
            }
        }

        public virtual string Email
        {
            get {
                return _dbContactPerson.Email;
            }
            set {
                _dbContactPerson.Email = value;
            }
        }

        public void Save()
        {
            using (ISession session = UserContext.SessionFactory.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        using (AppliactionContext.Log.LogTime(this, String.Format("Save contact persone '{0} {1}'.", FirstName, LastName)))
                        {
                            session.SaveOrUpdate(_dbContactPerson);
                            tx.Commit();
                        }
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

        public void Reload()
        {
            using (ISession session = UserContext.SessionFactory.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        using (AppliactionContext.Log.LogTime(this, String.Format("Reload contact person '{0} {1}'.", FirstName, LastName)))
                        {
                            DbContactPerson reloadedContactPerson = session.Load<DbContactPerson>(_dbContactPerson.Id);

                            _dbContactPerson.FirstName = reloadedContactPerson.FirstName;
                            _dbContactPerson.LastName = reloadedContactPerson.LastName;
                            _dbContactPerson.PhoneNumber = reloadedContactPerson.PhoneNumber;
                            _dbContactPerson.Email = reloadedContactPerson.Email;

                            tx.Commit();
                        }
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

        public void Delete()
        {
            using (ISession session = UserContext.SessionFactory.OpenSession())
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        using (AppliactionContext.Log.LogTime(this, String.Format("Delete contact person '{0} {1}'.", FirstName, LastName)))
                        {
                            session.Delete(_dbContactPerson);
                            tx.Commit();
                        }
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

        internal DbContactPerson DbContactPerson
        {
            get {
                return _dbContactPerson;
            }
        }

        private readonly DbContactPerson _dbContactPerson;
    }
}