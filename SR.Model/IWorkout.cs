using System;

using SR.Core.Users;

namespace SR.Model
{
    public interface IWorkout
    {
        Guid Id { get; set; }

        IUser Coach { get; set; }
    }
}
