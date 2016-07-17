using SR.Core;
using SR.Core.UserManagement;

namespace SR.CoreImpl
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
