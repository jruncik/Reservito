using System;
using System.Collections.Generic;

using SR.Core;
using SR.Core.Users;

namespace SR.Model
{
    public interface ICourse : IDbStorable
    {
        Guid Id { get; set; }

        string Name { get; set; }

        IUser Coach { get; set; }

        int Price { get; set; }

        int Capacity { get; set; }

        int Length { get; set; }

        IEnumerable<IWorkout> Workouts { get; }

        void AddWorkout(IWorkout workoutToAdd);

        void RemoveWorkout(IWorkout workoutToRemove);
    }
}
