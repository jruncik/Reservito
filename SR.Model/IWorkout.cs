using System;
using System.Collections.Generic;

using SR.Core.Users;
using SR.Core;

namespace SR.Model
{
    public interface IWorkout : IDbStorable
    {
        Guid Id { get; set; }

        DateTime Time { get; set; }

        int Capacity { get; set; }

        int Price { get; set; }

        IEnumerable<IUser> Cliens { get; }

        void AddClient(IUser clientToAdd);

        void RemoveClient(IUser clientToRemove);
    }
}
