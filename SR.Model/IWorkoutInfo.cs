using System;
using SR.Core;

namespace SR.Model
{
    public interface IWorkoutInfo : IDbStorable
    {
        Guid Id { get; set; }

        int Price { get; set; }

        int Capacity { get; set; }

        int Length { get; set; }
    }
}
