using SR.Core.Rights;

namespace SR.CoreImpl.Rights
{
    internal class MasterRights : IRights
    {
        public bool IsInRole(string role)
        {
            throw new System.NotImplementedException();
        }

        public bool IsInRole(Roles roles)
        {
            return true;
        }
    }
}