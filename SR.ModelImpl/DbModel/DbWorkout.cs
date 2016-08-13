using System;
using System.Collections.Generic;
using SR.Core;

namespace SR.ModelImpl.DbModel
{
    public class DbWorkout : IDbCloneable
    {
        public virtual Guid Id { get; set; }

        public virtual DateTime Time { get; set; }

        public virtual DbWorkoutInfo WorkoutInfo { get; set; }

        public virtual IList<DbUser> Cliens { get; set; }

        public DbWorkout()
        {
            Id = Guid.Empty;
            Time = DateTime.MinValue;
            WorkoutInfo = null;

            Cliens = new List<DbUser>();
        }

        public DbWorkout(DbWorkout other)
        {
            Id = other.Id;
            Time = other.Time;

            WorkoutInfo = CloneHelper.SafeClone<DbWorkoutInfo>(other.WorkoutInfo);
            Cliens = CloneHelper.SafeCloneList<DbUser>(other.Cliens);
        }

        public virtual T Clone<T>() where T : class
        {
            return (T)(object)(new DbWorkout(this));
        }
    }
}
