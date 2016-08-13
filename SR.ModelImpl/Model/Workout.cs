using System;
using System.Collections.Generic;

using SR.Core.Users;
using SR.Model;
using SR.ModelImpl.DbModel;
using SR.Core.Context;
using System.Linq;

namespace SR.ModelImpl.Model
{
    public class Workout : IWorkout
    {

        public Workout(ICourse ownerCourse) :
            this(ownerCourse, new DbWorkout())
        {
        }

        public Workout(ICourse ownerCourse, DbWorkout dbWorkout)
        {
            _ownerCourse = ownerCourse;
            _dbWorkout = dbWorkout;

            _clients = CreateClientsFromDbUsers(_dbWorkout.Cliens);
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

        public IWorkoutInfo WorkoutInfo
        {
            get
            {
                if (_workoutInfo != null)
                {
                    return _workoutInfo;
                }

                return ((Course)_ownerCourse).WorkoutInfo;
            }

            set
            {
                _workoutInfo = value;
                if (_workoutInfo != null)
                {
                    _dbWorkout.WorkoutInfo = _workoutInfo.GetDbObject<DbWorkoutInfo>();
                }
                else
                {
                    _dbWorkout.WorkoutInfo = null;
                }
            }
        }

        IEnumerable<IUser> IWorkout.Cliens
        {
            get { return _clients.Select(c => c); }
        }

        public void AddClient(IUser clientToAdd)
        {
            if (!_clients.Contains(clientToAdd))
            {
                _clients.Add(clientToAdd);
                _dbWorkout.Cliens.Add(clientToAdd.GetDbObject<DbUser>());
            }
        }

        public void RemoveClient(IUser clientToRemove)
        {
            if (_clients.Contains(clientToRemove))
            {
                _clients.Remove(clientToRemove);
                _dbWorkout.Cliens.Remove(clientToRemove.GetDbObject<DbUser>());
            }
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
                _dbWorkout.WorkoutInfo = loadedWorkout.WorkoutInfo;
                _clients = CreateClientsFromDbUsers(_dbWorkout.Cliens);
            }
        }

        public void Delete()
        {
            using (AppliactionContext.Log.LogTime(this, $"Delete workout '{Id}'."))
            {
                UserContext.DbOperations.Delete(_dbWorkout);
            }
        }

        public T GetDbObject<T>() where T : class
        {
            return (T)(object)_dbWorkout;
        }

        private List<IUser> CreateClientsFromDbUsers(IList<DbUser> dbClients)
        {
            if (dbClients == null)
            {
                return new List<IUser>(0);
            }

            List<IUser> clients = new List<IUser>(dbClients.Count);
            foreach (DbUser dbClient in dbClients)
            {
                IUser client = AppliactionContext.UserManagement.TryFindUserById(dbClient.Id);
                if (client == null)
                {
                    AppliactionContext.Log.Critical(this, $"Client '{dbClient.FirstName}', '{dbClient.LastName}', '{dbClient.Id} wasn't found in AppliactionContext.UserManagement!");
                    continue;
                }

                clients.Add(client);
            }

            return clients;
        }

        private readonly ICourse _ownerCourse;
        private readonly DbWorkout _dbWorkout;

        private IList<IUser> _clients;
        private IWorkoutInfo _workoutInfo;
    }
}
