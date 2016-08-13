using System;
using System.Collections.Generic;

using SR.Core;

namespace SR.ModelImpl.DbModel
{
    public class DbCourse : IDbCloneable
    {
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual DbUser Coach { get; set; }

        public virtual DbWorkoutInfo WorkoutInfo { get; set; }

        public virtual IList<DbWorkout> Workouts { get; set; }

        public DbCourse() :
            this((DbUser)null)
        {
        }

        public DbCourse(DbUser coach)
        {
            Coach = coach;
            Name = String.Empty;
            WorkoutInfo = new DbWorkoutInfo();
            Workouts = new List<DbWorkout>();
        }

        public DbCourse(DbCourse other)
        {
            Id = other.Id;
            Name = other.Name;
            Coach = other.Coach.Clone<DbUser>();
            WorkoutInfo = other.WorkoutInfo.Clone<DbWorkoutInfo>();

            Workouts = CloneHelper.SafeCloneList<DbWorkout>(other.Workouts);
        }

        public virtual T Clone<T>() where T : class
        {
            return (T)(object)(new DbCourse(this));
        }
    }
}
