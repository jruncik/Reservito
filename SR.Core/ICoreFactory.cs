using TV.Core.UserManagement;

namespace TV.Core
{
    public interface ICoreFactory
    {
        IUserManagement CreateUserManagement();

        IAutentication CreateAutentication(IUserManagement userManagement);
    }
}