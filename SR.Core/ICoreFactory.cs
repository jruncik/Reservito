using SR.Core.UserManagement;

namespace SR.Core
{
    public interface ICoreFactory
    {
        IUserManagement CreateUserManagement();

        IAutentication CreateAutentication(IUserManagement userManagement);
    }
}