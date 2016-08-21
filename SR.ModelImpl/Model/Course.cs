using System;
using System.Collections.Generic;
using System.Linq;
using SR.Core.Context;
using SR.Core.Users;
using SR.Model;
using SR.ModelImpl.DbModel;

namespace SR.ModelImpl.Model
{
    internal class Course : ICourse
    {
        internal Course(IUser coach)
        {
            _coach = coach;

            _workouts = new List<IWorkout>();
            _dbCourse = new DbCourse(_coach.GetDbObject<User>());

            _workoutInfo = new WorkoutInfo();
        }

        public Guid Id
        {
            get { return _dbCourse.Id; }
            set { _dbCourse.Id = value; }
        }

        public string Name
        {
            get { return _dbCourse.Name; }
            set { _dbCourse.Name = value; }
        }

        public IUser Coach
        {
            get { return _coach; }
            set { throw new NotImplementedException(); }
        }

        public int Capacity
        {
            get { return _workoutInfo.Capacity; }
            set { _workoutInfo.Capacity = value; }
        }

        public int Price
        {
            get { return _workoutInfo.Price; }
            set { _workoutInfo.Price = value; }
        }

        public int Length
        {
            get { return _workoutInfo.Length; }
            set { _workoutInfo.Length = value; }
        }

        public IEnumerable<IWorkout> Workouts
        {
             get { return _workouts.Select(c => c); }
        }

        public IWorkout AddNewWorkout()
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

        public void RemoveWorkout(IWorkout workoutToRemove)
        {
            if (!_workouts.Contains(workoutToRemove))
            {
                _workouts.Remove(workoutToRemove);
            }
        }

        public void Save()
        {
            using (AppliactionContext.Log.LogTime(this, $"Save course '{Id}', Name: {Name}, Coach: {Coach}."))
            {
                UserContext.DbOperations.Save(_dbCourse);
            }
        }

        public void Load()
        {
            using (AppliactionContext.Log.LogTime(this, $"Reload course '{Id}', Name: {Name}, Coach: {Coach}."))
            {
                DbCourse loadedCourse = UserContext.DbOperations.Load<DbCourse>(_dbCourse.Id);

                _dbCourse.Name = loadedCourse.Name;

                _dbCourse.WorkoutInfo = loadedCourse.WorkoutInfo;
                _workoutInfo = new WorkoutInfo(_dbCourse.WorkoutInfo);

                _workouts = CreateWorkoutsFromDbWorkouts(_dbCourse.Workouts);
            }
        }

        public void Delete()
        {
            using (AppliactionContext.Log.LogTime(this, $"Delete course '{Id}', Name: {Name}, Coach: {Coach}."))
            {
                UserContext.DbOperations.Delete(_dbCourse);
            }
        }

        public T GetDbObject<T>() where T : class
        {
            throw new NotImplementedException();
        }

        internal IWorkoutInfo WorkoutInfo
        {
            get { return _workoutInfo; }
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

        private readonly DbCourse _dbCourse;

        private IList<IWorkout> _workouts;
        private IWorkoutInfo _workoutInfo;
        private IUser _coach;
    }
}
