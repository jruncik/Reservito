using System;
using System.Collections.Generic;

using SR.Core.Users;

namespace SR.Model
{
    public interface IWorkout
    {
        Guid Id { get; set; }

        DateTime Time { get; set; }

        IList<IUser> Cliens { get; }
    }
}
