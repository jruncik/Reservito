using System;
using System.Collections.Generic;
using System.Linq;
using SR.Core;
using SR.Core.Context;
using SR.Core.Users;
using SR.Model;

namespace SR.ModelImpl.Model
{
    internal class Course : ICourse, IDbCloneable
    {
        protected Course()
        {
            Coach = null;
            Name = String.Empty;
            _workoutInfo = new WorkoutInfo();
            _workouts = new List<IWorkout>();
        }

        internal Course(IUser coach)
        {
            _coach = coach;
            _workouts = new List<IWorkout>();
            _workoutInfo = new WorkoutInfo();
        }

        internal Course(Course other)
        {
            _coach = other._coach;
            _workouts = new List<IWorkout>();
        }

        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual IUser Coach
        {
            get { return _coach; }
            set { _coach = value; }
        }

        public virtual int Capacity
        {
            get { return _workoutInfo.Capacity; }
            set { _workoutInfo.Capacity = value; }
        }

        public virtual int Price
        {
            get { return _workoutInfo.Price; }
            set { _workoutInfo.Price = value; }
        }

        public virtual int Length
        {
            get { return _workoutInfo.Length; }
            set { _workoutInfo.Length = value; }
        }

        public virtual IEnumerable<IWorkout> Workouts
        {
             get { return _workouts.Select(c => c); }
        }

        public virtual IWorkout AddNewWorkout()
        {
            IWorkout newWorkout = new Workout(this);
            AddWorkout(newWorkout);
            return newWorkout;
        }

        private void AddWorkout(IWorkout workoutToAdd)
        {
            if (!_workouts.Contains(workoutToAdd))
            {
                _workouts.Add(workoutToAdd);
            }
        }

        public virtual void RemoveWorkout(IWorkout workoutToRemove)
        {
            if (!_workouts.Contains(workoutToRemove))
            {
                _workouts.Remove(workoutToRemove);
            }
        }

        public virtual void Save()
        {
            using (AppliactionContext.Log.LogTime(this, $"Save course '{Id}', Name: {Name}, Coach: {Coach}."))
            {
                UserContext.DbOperations.Save(this);
            }
        }

        public virtual void Load()
        {
            using (AppliactionContext.Log.LogTime(this, $"Reload course '{Id}', Name: {Name}, Coach: {Coach}."))
            {
                Course loadedCourse = UserContext.DbOperations.Load<Course>(Id);

                Name = loadedCourse.Name;
                _workoutInfo = new WorkoutInfo(loadedCourse.WorkoutInfo);

                // _workouts = CreateWorkoutsFromDbWorkouts(loadedCourse.Workouts);
            }
        }

        public virtual void Delete()
        {
            using (AppliactionContext.Log.LogTime(this, $"Delete course '{Id}', Name: {Name}, Coach: {Coach}."))
            {
                UserContext.DbOperations.Delete(_dbCourse);
            }
        }

        public virtual T GetDbObject<T>() where T : class
        {
            return (T)(object)this;
        }

        public virtual T Clone<T>() where T : class
        {
            return (T)(object)(new Course(this));
        }

        protected internal virtual IWorkoutInfo WorkoutInfo
        {
            get { return _workoutInfo; }
            set { _workoutInfo = value; }
        }

        protected virtual IList<IWorkout> WorkoutsList
        {
            get { return _workouts; }
            set { _workouts = value; }
        }

        private List<IWorkout> CreateWorkoutsFromDbWorkouts(IList<Workout> dbWorkouts)
        {
            if (dbWorkouts == null)
            {
                return new List<IWorkout>(0);
            }

            List<IWorkout> workouts = new List<IWorkout>(dbWorkouts.Count);
            foreach (Workout dbWorkout in dbWorkouts)
            {
                Workout workout = new Workout(this);
                workouts.Add(workout);
            }

            return workouts;
        }

        private IList<IWorkout> _workouts;
        private IWorkoutInfo _workoutInfo;
        private IUser _coach;
    }
}
