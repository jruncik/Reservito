using TV.Core;
using TV.Core.UserManagement;

namespace TV.CoreImpl
{
    public class CoreFactory : ICoreFactory
    {
        public IUserManagement CreateUserManagement()
        {
            return new UserManagement.UserManagement();
        }

        public IAutentication CreateAutentication(IUserManagement userManagement)
        {
            return new Autentication.Autentication(userManagement);
        }
    }
}
