using System;

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
            get
            {
                return _dbContactPerson.Id;
            }
            set
            {
                _dbContactPerson.Id = value;
            }
        }

        public virtual string FirstName
        {
            get
            {
                return _dbContactPerson.FirstName;
            }
            set
            {
                _dbContactPerson.FirstName = value;
            }
        }

        public virtual string LastName
        {
            get
            {
                return _dbContactPerson.LastName;
            }
            set
            {
                _dbContactPerson.LastName = value;
            }

        }

        public virtual string PhoneNumber
        {
            get
            {
                return _dbContactPerson.PhoneNumber;
            }
            set
            {
                _dbContactPerson.PhoneNumber = value;
            }
        }

        public virtual string Email
        {
            get
            {
                return _dbContactPerson.Email;
            }
            set
            {
                _dbContactPerson.Email = value;
            }
        }

        public void Save()
        {
            using (AppliactionContext.Log.LogTime(this, $"Save contact person '{FirstName} {LastName}'."))
            {
                UserContext.DbOperations.Save(_dbContactPerson);
            }
        }

        public void Reload()
        {
            using (AppliactionContext.Log.LogTime(this, $"Reload contact person '{FirstName} {LastName}'."))
            {
                DbContactPerson reloadedContactPerson = UserContext.DbOperations.Reload<DbContactPerson>(_dbContactPerson.Id);

                _dbContactPerson.FirstName = reloadedContactPerson.FirstName;
                _dbContactPerson.LastName = reloadedContactPerson.LastName;
                _dbContactPerson.PhoneNumber = reloadedContactPerson.PhoneNumber;
                _dbContactPerson.Email = reloadedContactPerson.Email;

            }
        }

        public void Delete()
        {
            using (AppliactionContext.Log.LogTime(this, $"Delete contact person '{FirstName} {LastName}'."))
            {
                UserContext.DbOperations.Delete(_dbContactPerson);
            }
        }

        internal DbContactPerson DbContactPerson
        {
            get
            {
                return _dbContactPerson;
            }
        }

        private readonly DbContactPerson _dbContactPerson;
    }
}