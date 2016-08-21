using System;
using System.Collections.Generic;

using SR.Core;
using SR.ModelImpl.Model;

namespace SR.ModelImpl.DbModel
{
    public class DbCourse : IDbCloneable
    {
        public virtual Guid Id { get; set; }

        public virtual string Name { get; set; }

        public virtual User Coach { get; set; }

        public virtual WorkoutInfo WorkoutInfo { get; set; }

        public virtual IList<Workout> Workouts { get; set; }

        public DbCourse() :
            this((User)null)
        {
        }

        public DbCourse(User coach)
        {
            Coach = coach;
            Name = String.Empty;
            WorkoutInfo = new WorkoutInfo();
            Workouts = new List<Workout>();
        }

        public DbCourse(DbCourse other)
        {
            Id = other.Id;
            Name = other.Name;
            Coach = other.Coach.Clone<User>();
            WorkoutInfo = other.WorkoutInfo.Clone<WorkoutInfo>();

            Workouts = CloneHelper.SafeCloneList<Workout>(other.Workouts);
        }

        public virtual T Clone<T>() where T : class
        {
            return (T)(object)(new DbCourse(this));
        }
    }
}
