using System;
using System.Collections.Generic;

using SR.Core.Users;
using SR.Model;

namespace SR.ModelImpl.Model
{
    internal class Workout : IWorkout
    {
        public IList<IUser> Cliens
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Guid Id
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime Time
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
