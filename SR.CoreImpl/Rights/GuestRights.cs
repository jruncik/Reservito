using TV.Core.Rights;

namespace TV.CoreImpl.Rights
{
    internal class GuestRights : IRights
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