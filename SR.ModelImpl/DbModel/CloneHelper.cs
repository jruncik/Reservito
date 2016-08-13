using System.Collections.Generic;

using SR.Core;

namespace SR.ModelImpl.DbModel
{
    internal static class CloneHelper
    {
        internal static T SafeClone<T>(T other) where T : class, IDbCloneable
        {
            if (other == null)
            {
                return null;
            }

            return other.Clone<T>();
        }

        internal static IList<T> SafeCloneList<T>(IList<T> other) where T : class, IDbCloneable
        {
            if (other == null)
            {
                return new List<T>(0);
            }

            IList<T> clone = new List<T>(other.Count);

            foreach (T otherItem in other)
            {
                clone.Add(otherItem.Clone<T>());
            }

            return clone;
        }
    }
}
