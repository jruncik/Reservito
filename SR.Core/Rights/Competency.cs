namespace TV.Core.Rights
{
    public enum Roles : long
    {
        Unknown,
        ManageUsers,
    }

    public class RolesHelper : EnumHelper<Roles>
    {
        static RolesHelper()
        {
            _defaultvalue = Roles.Unknown;
        }
    }
}