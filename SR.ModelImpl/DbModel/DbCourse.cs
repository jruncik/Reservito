using System;
using System.Collections.Generic;

namespace SR.ModelImpl.DbModel
{
    public class DbCourse : ICloneable
    {
        public virtual string Name { get; set; }
        public virtual DbUser Coach { get; set; }
        public virtual IList<DbWorkout> Workouts { get; }

        public DbCourse(DbUser coach)
        {
            Name = String.Empty;
            Coach = coach;

            Workouts = new List<DbWorkout>();
        }

        public DbCourse(DbCourse other)
        {
            Name = other.Name;
            Coach = (DbUser)other.Coach.Clone();

            Workouts = new List<DbWorkout>(other.Workouts.Count);
            foreach (DbWorkout otherWorkout in other.Workouts)
            {
                Workouts.Add((DbWorkout)otherWorkout.Clone());
            }
        }

        public object Clone()
        {
            return new DbCourse(this);
        }
    }
}
