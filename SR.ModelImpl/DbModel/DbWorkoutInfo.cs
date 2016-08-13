using System;
using SR.Core;

namespace SR.ModelImpl.DbModel
{
    public class DbWorkoutInfo : IDbCloneable
    {
        public virtual Guid Id { get; set; }

        public virtual int Capacity { get; set; }

        public virtual int Price { get; set; }

        public virtual int Length { get; set; }

        public DbWorkoutInfo()
        {
            Id = Guid.Empty;
            Capacity = 0;
            Price = 0;
            Length = 0;
        }

        public DbWorkoutInfo(DbWorkoutInfo other)
        {
            Id = other.Id;
            Capacity = other.Capacity;
            Price = other.Price;
            Length = other.Length;
        }

        public virtual T Clone<T>() where T : class
        {
            return (T)(object)(new DbWorkoutInfo(this));
        }
    }
}
