using SR.Core.Rights;

namespace SR.CoreImpl.Rights
{
    internal class EmptyRights : IRights
    {
        public bool IsInRole(string role)
        {
            return false;
        }

        public bool IsInRole(Roles roles)
        {
            return false;
        }
    }
}