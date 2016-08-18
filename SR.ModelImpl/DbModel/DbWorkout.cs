using System;
using System.Collections.Generic;
using SR.Core;
using SR.Model;
using SR.ModelImpl.Model;

namespace SR.ModelImpl.DbModel
{
    public class DbWorkout : IDbCloneable
    {
        public virtual Guid Id { get; set; }

        public virtual DateTime Time { get; set; }

        public virtual WorkoutInfo WorkoutInfo { get; set; }

        public virtual IList<User> Cliens { get; set; }

        public DbWorkout()
        {
            Id = Guid.Empty;
            Time = DateTime.MinValue;
            WorkoutInfo = null;

            Cliens = new List<User>();
        }

        public DbWorkout(DbWorkout other)
        {
            Id = other.Id;
            Time = other.Time;

            WorkoutInfo = CloneHelper.SafeClone<WorkoutInfo>(other.WorkoutInfo);
            Cliens = CloneHelper.SafeCloneList<User>(other.Cliens);
        }

        public virtual T Clone<T>() where T : class
        {
            return (T)(object)(new DbWorkout(this));
        }
    }
}
