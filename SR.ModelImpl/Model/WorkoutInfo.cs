using SR.Core.Context;
using SR.Model;
using SR.ModelImpl.DbModel;
using System;

namespace SR.ModelImpl.Model
{
    public class WorkoutInfo : IWorkoutInfo
    {
        public WorkoutInfo() :
            this(new DbWorkoutInfo())
        {
        }

        internal WorkoutInfo(DbWorkoutInfo dbWorkoutInfo)
        {
            _dbWorkoutInfo = dbWorkoutInfo;
        }


        public Guid Id
        {
            get { return _dbWorkoutInfo.Id; }
            set { _dbWorkoutInfo.Id = value; }
        }

        public int Capacity
        {
            get { return _dbWorkoutInfo.Capacity; }
            set { _dbWorkoutInfo.Capacity = value; }
        }

        public int Price
        {
            get { return _dbWorkoutInfo.Price; }
            set { _dbWorkoutInfo.Price = value; }
        }

        public int Length
        {
            get { return _dbWorkoutInfo.Length; }
            set { _dbWorkoutInfo.Length = value; }
        }

        public void Save()
        {
            using (AppliactionContext.Log.LogTime(this, $"Save workout info '{Id}', Price: {Price}, Capacity: {Capacity}."))
            {
                UserContext.DbOperations.Save(_dbWorkoutInfo);
            }
        }

        public void Load()
        {
            using (AppliactionContext.Log.LogTime(this, $"Reload workout info '{Id}', Price: {Price}, Capacity: {Capacity}."))
            {
                DbWorkoutInfo loadedWorkout = UserContext.DbOperations.Load<DbWorkoutInfo>(_dbWorkoutInfo.Id);
            }
        }

        public void Delete()
        {
            using (AppliactionContext.Log.LogTime(this, $"Delete workout info '{Id}'."))
            {
                UserContext.DbOperations.Delete(_dbWorkoutInfo);
            }
        }

        public T GetDbObject<T>() where T : class
        {
            return (T)(object)_dbWorkoutInfo;
        }

        private DbWorkoutInfo _dbWorkoutInfo;
    }
}
