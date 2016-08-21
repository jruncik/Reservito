using System;
using System.Collections.Generic;
using System.Linq;

using SR.Core.Users;
using SR.Model;
using SR.ModelImpl.DbModel;
using SR.Core.Context;
using SR.Core;

namespace SR.ModelImpl.Model
{
    public class Workout : IWorkout, IDbCloneable
    {
        protected Workout()
        {
            _ownerCourse = null;
            _clients = new List<IUser>();
            _clientsIds = new List<Guid>();

            Id = Guid.Empty;
            Time = DateTime.MinValue;
            _workoutInfo = null;
        }

        internal Workout(ICourse ownerCourse)
        {
            _ownerCourse = ownerCourse;
            _clients = new List<IUser>();
            _clientsIds = new List<Guid>();
        }

        internal Workout(Workout other)
        {
            _ownerCourse = other._ownerCourse;
            Id = other.Id;
            Time = other.Time;

            WorkoutInfo = CloneHelper.SafeClone<WorkoutInfo>(other.WorkoutInfo);
        }

        public virtual Guid Id { get; set; }

        public virtual DateTime Time { get; set; }

        public virtual WorkoutInfo WorkoutInfo { get; set; }

        public virtual IEnumerable<IUser> Cliens
        {
            get { return _clients.Select(w => w); }
        }

        public virtual int Price
        {
            get { return SafeWorkoutInfo.Price; }

            set
            {
                if (Price != value)
                {
                    EnsureWorkoutInfo();
                    _workoutInfo.Price = value;
                }
            }
        }

        public virtual int Capacity
        {
            get { return SafeWorkoutInfo.Capacity; }

            set
            {
                if (Capacity != value)
                {
                    EnsureWorkoutInfo();
                    _workoutInfo.Capacity = value;
                }
            }
        }

        public virtual int Length
        {
            get { return SafeWorkoutInfo.Length; }

            set
            {
                if (Length != value)
                {
                    EnsureWorkoutInfo();
                    _workoutInfo.Length = value;
                }
            }
        }

        public virtual void AddClient(IUser clientToAdd)
        {
            if (!_clients.Contains(clientToAdd))
            {
                _clients.Add(clientToAdd);
                _clientsIds.Add(clientToAdd.Id);
            }
        }

        public virtual void RemoveClient(IUser clientToRemove)
        {
            if (_clients.Contains(clientToRemove))
            {
                _clients.Remove(clientToRemove);
                _clientsIds.Remove(clientToRemove.Id);
            }
        }

        public virtual void Save()
        {
            using (AppliactionContext.Log.LogTime(this, $"Save workout '{Id}'."))
            {
                UserContext.DbOperations.Save(this);
            }
        }

        public virtual void Load()
        {
            using (AppliactionContext.Log.LogTime(this, $"Reload workout '{Id}'."))
            {
                Workout loadedWorkout = UserContext.DbOperations.Load<Workout>(Id);

                Time = loadedWorkout.Time;

                _clientsIds = loadedWorkout._clientsIds;
                _clients = CreateClientsFromGuids(loadedWorkout._clientsIds);

                _workoutInfo = CreateWorkoutInfo(loadedWorkout.WorkoutInfo);
            }
        }

        public virtual void Delete()
        {
            using (AppliactionContext.Log.LogTime(this, $"Delete workout '{Id}'."))
            {
                UserContext.DbOperations.Delete(_dbWorkout);
            }
        }

        public virtual T Clone<T>() where T : class
        {
            return (T)(object)(new Workout(this));
        }

        public virtual T GetDbObject<T>() where T : class
        {
            return (T)(object)this;
        }

        private IWorkoutInfo ParentWorkoutInfo
        {
            get { return ((Course)_ownerCourse).WorkoutInfo; }
        }

        private IWorkoutInfo SafeWorkoutInfo
        {
            get
            {
                if (_workoutInfo == null)
                {
                    return ParentWorkoutInfo;
                }

                return _workoutInfo;
            }
        }

        protected virtual IList<Guid> ClientsIds
        {
            get { return _clientsIds; }
            set { _clientsIds = value; }
        }

        private void EnsureWorkoutInfo()
        {
            if (_workoutInfo == null)
            {
                _workoutInfo = new WorkoutInfo();
            }
        }

        private List<IUser> CreateClientsFromGuids(IList<Guid> idsClients)
        {
            if (idsClients == null)
            {
                return new List<IUser>(0);
            }

            List<IUser> clients = new List<IUser>(idsClients.Count);
            foreach (Guid idClient in idsClients)
            {
                IUser client = AppliactionContext.UserManagement.TryFindUserById(idClient);
                if (client == null)
                {
                    AppliactionContext.Log.Critical(this, $"Client '{idClient}' wasn't found in AppliactionContext.UserManagement!");
                    continue;
                }

                clients.Add(client);
            }

            return clients;
        }

        private IWorkoutInfo CreateWorkoutInfo(WorkoutInfo workoutInfo)
        {
            if (workoutInfo == null)
            {
                return null;
            }

            return new WorkoutInfo(workoutInfo);
        }

        private readonly ICourse _ownerCourse;

        private IList<IUser> _clients;
        private IList<Guid> _clientsIds;

        private IWorkoutInfo _workoutInfo;
    }
}
