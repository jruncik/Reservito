﻿using NHibernate.Cfg;
using SR.Core;
using SR.Core.Context;
using SR.Core.Log;
using SR.Core.UserManagement;
using SR.CoreImpl;
using SR.CoreImpl.Log;

namespace SR.Tiskarna
{
    public class TiskarnaVosahlo : ContextSingleton<TiskarnaVosahlo>
    {
        public TiskarnaVosahlo()
        {
            InitApplicationContext();
            InitUserContext();

            _coreFactory = new CoreFactory();

            _userManagement = _coreFactory.CreateUserManagement();
            _autentication = _coreFactory.CreateAutentication(_userManagement);
        }

        private static void InitApplicationContext()
        {
            ILog log = new Log();

            Configuration configuartion = new Configuration();
            configuartion.Configure();

            new AppliactionContext(log, configuartion);
        }

        private static void InitUserContext()
        {
            new UserContext();
        }

        public static IAutentication Autentication
        {
            get { return Instance._autentication; }
        }

        public static IUserManagement UserManagement
        {
            get { return Instance._userManagement; }
        }

       private readonly ICoreFactory _coreFactory;
        private readonly IAutentication _autentication;
        private readonly IUserManagement _userManagement;
    }
}
