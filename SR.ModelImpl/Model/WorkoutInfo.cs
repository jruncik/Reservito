using System;

using SR.Core;
using SR.Core.Context;

using SR.Model;

namespace SR.ModelImpl.Model
{
    public class WorkoutInfo : IWorkoutInfo, IDbCloneable
    {
        public WorkoutInfo()
        {
            Id = Guid.Empty;
            Capacity = 0;
            Price = 0;
            Length = 0;
        }

        public WorkoutInfo(WorkoutInfo other)
        {
            Id = other.Id;
            Capacity = other.Capacity;
            Price = other.Price;
            Length = other.Length;
        }

        public virtual Guid Id { get; set; }

        public virtual int Capacity { get; set; }

        public virtual int Price { get; set; }

        public virtual int Length { get; set; }

        public virtual void Save()
        {
            using (AppliactionContext.Log.LogTime(this, $"Save workout info '{Id}', Price: {Price}, Capacity: {Capacity}."))
            {
                UserContext.DbOperations.Save(this);
            }
        }

        public virtual void Load()
        {
            using (AppliactionContext.Log.LogTime(this, $"Reload workout info '{Id}', Price: {Price}, Capacity: {Capacity}."))
            {
                WorkoutInfo loadedWorkout = UserContext.DbOperations.Load<WorkoutInfo>(Id);

                Id = loadedWorkout.Id;
                Capacity = loadedWorkout.Capacity;
                Price = loadedWorkout.Price;
                Length = loadedWorkout.Length;
            }
        }

        public virtual void Delete()
        {
            using (AppliactionContext.Log.LogTime(this, $"Delete workout info '{Id}'."))
            {
                UserContext.DbOperations.Delete(this);
            }
        }

        public virtual T GetDbObject<T>() where T : class
        {
            return (T)(object)this;
        }

        public virtual T Clone<T>() where T : class
        {
            return (T)(object)(new WorkoutInfo(this));
        }
    }
}
