using System;
using System.Collections.Generic;

using SR.Core.Users;

namespace SR.Model
{
    public interface ICourse
    {
        Guid Id { get; set; }

        string Name { get; set; }
        IUser Coach { get; set; }
        int Capacity { get; set; }
        int Price { get; set; }

        IList<IWorkout> Workouts { get; }
    }
}
