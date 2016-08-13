using System;
using System.Collections.Generic;

using SR.Core.Users;
using SR.Model;

namespace SR.ModelImpl.Model
{
    public class Course : ICourse
    {
        public Course()
        {
            _workoutInfo = new WorkoutInfo();
        }

        public Guid Id
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public IUser Coach
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public IWorkoutInfo WorkoutInfo
        {
            get { return _workoutInfo; }
        }

        IEnumerable<IWorkout> Workouts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        IEnumerable<IWorkout> ICourse.Workouts
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void AddClient(IWorkout workoutToAdd)
        {
            throw new NotImplementedException();
        }

        public void RemoveClient(IWorkout workoutToRemove)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public T GetDbObject<T>() where T : class
        {
            throw new NotImplementedException();
        }

        private IWorkoutInfo _workoutInfo;
    }
}
