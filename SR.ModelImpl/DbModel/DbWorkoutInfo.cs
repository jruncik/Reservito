using System;

namespace SR.ModelImpl.DbModel
{
    public class DbWorkoutInfo : ICloneable
    {
        public virtual Guid Id { get; set; }

        public virtual int Capacity { get; set; }

        public virtual int Price { get; set; }

        public DbWorkoutInfo()
        {
            Id = Guid.Empty;
            Capacity = 0;
            Price = 0;
        }

        public DbWorkoutInfo(DbWorkoutInfo other)
        {
            Id = other.Id;
            Capacity = other.Capacity;
            Price = other.Price;
        }

        public virtual object Clone()
        {
            return new DbWorkoutInfo(this);
        }
    }
}
