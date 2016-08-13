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

        IWorkoutInfo WorkoutInfo { get; }

        IEnumerable<IWorkout> Workouts { get; }

        void AddClient(IWorkout workoutToAdd);

        void RemoveClient(IWorkout workoutToRemove);

    }
}
