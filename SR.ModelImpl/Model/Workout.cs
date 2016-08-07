using System;
using System.Collections.Generic;

using SR.Core.Users;
using SR.Model;
using SR.ModelImpl.DbModel;
using SR.Core.Context;

namespace SR.ModelImpl.Model
{
    public class Workout : IWorkout
    {
        public Workout()
        {
            _dbWorkout = new DbWorkout();
            _clients = new List<IUser>();
        }

        public IList<IUser> Cliens
        {
            get { return _clients; }
        }

        public Guid Id
        {
            get { return _dbWorkout.Id; }
            set { _dbWorkout.Id = value; }
        }

        public DateTime Time
        {
            get { return _dbWorkout.Time; }
            set { _dbWorkout.Time = value; }
        }

        public int Capacity
        {
            get { return _dbWorkout.Capacity; }
            set { _dbWorkout.Capacity = value; }
        }

        public int Price
        {
            get { return _dbWorkout.Price; }
            set { _dbWorkout.Price = value; }
        }

        public void Save()
        {
            using (AppliactionContext.Log.LogTime(this, $"Save workout '{Id}'."))
            {
                UserContext.DbOperations.Save(_dbWorkout);
            }
        }

        public void Load()
        {
            using (AppliactionContext.Log.LogTime(this, $"Reload workout '{Id}'."))
            {
                DbWorkout loadedWorkout = UserContext.DbOperations.Load<DbWorkout>(_dbWorkout.Id);

                _dbWorkout.Time = loadedWorkout.Time;

                _clients.Clear();
                /*
                foreach (DbUser dbClient in _dbWorkout.Cliens)
                {
                    IUser client = AppliactionContext.UserManagement.TryFindUserById(dbClient.Id);
                    if (client == null)
                    {
                        AppliactionContext.Log.Critical(this, $"Client '{dbClient.FirstName}', '{dbClient.LastName}', '{dbClient.Id} wasn't found in AppliactionContext.UserManagement!");
                        continue;
                    }

                    _clients.Add(client);
                }
                */
            }
        }

        public void Delete()
        {
            using (AppliactionContext.Log.LogTime(this, $"Delete workout '{Id}'."))
            {
                UserContext.DbOperations.Delete(_dbWorkout);
            }
        }

        private DbWorkout _dbWorkout;
        private IList<IUser> _clients;
    }
}
