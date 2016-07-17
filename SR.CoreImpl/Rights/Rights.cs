using TV.Core.Rights;

namespace TV.CoreImpl.Rights
{
    internal class Rights : IRights
    {
        public static IRights Empty
        {
            get { return EmptyRights; }
        }

        public static IRights Master
        {
            get { return MasterRights; }
        }

        public static IRights Guest
        {
            get { return GuestRights; }
        }

        public Rights(Roles userRoles)
        {
            _userRoles = userRoles;
        }

        public bool IsInRole(string role)
        {
            Roles roles = RolesHelper.FromString(role);
            return IsInRole(roles);
        }

        public bool IsInRole(Roles roles)
        {
            return false;
        }

        private static readonly IRights EmptyRights = new EmptyRights();
        private static readonly IRights MasterRights = new MasterRights();
        private static readonly IRights GuestRights = new GuestRights();

        private readonly Roles _userRoles;
    }
}