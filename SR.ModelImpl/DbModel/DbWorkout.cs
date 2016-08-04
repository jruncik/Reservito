using System;
using System.Collections.Generic;

namespace SR.ModelImpl.DbModel
{
    public class DbWorkout : ICloneable
    {
        public virtual Guid Id { get; set; }

        public virtual DateTime Time { get; set; }
        public virtual int Capacity { get; set; }
        public virtual int Price { get; set; }

        public virtual IList<DbUser> Cliens { get; }

        public DbWorkout()
        {
            Id = Guid.Empty;
            Time = DateTime.MinValue;
            Capacity = 0;
            Price = 0;

            Cliens = new List<DbUser>();
        }

        public DbWorkout(DbWorkout other)
        {
            Id = other.Id;
            Time = other.Time;
            Capacity = other.Capacity;
            Price = other.Price;

            Cliens = new List<DbUser>(other.Cliens.Count);
            foreach (DbUser otherClient in other.Cliens)
            {
                Cliens.Add((DbUser)otherClient.Clone());
            }
        }

        public object Clone()
        {
            return new DbWorkout(this);
        }
    }
}
