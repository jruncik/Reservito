using System;
using System.Collections.Generic;

namespace SR.ModelImpl.DbModel
{
    public class DbWorkout : ICloneable
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

            if (other.WorkoutInfo != null)
            {
                WorkoutInfo = (DbWorkoutInfo)other.WorkoutInfo.Clone();
            }

            Cliens = new List<DbUser>(other.Cliens.Count);
            foreach (DbUser otherClient in other.Cliens)
            {
                Cliens.Add((DbUser)otherClient.Clone());
            }
        }

        public virtual object Clone()
        {
            return new DbWorkout(this);
        }
    }
}
