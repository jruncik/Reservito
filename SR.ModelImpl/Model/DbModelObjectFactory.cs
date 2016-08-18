using System;
using SR.Core.Users;

using SR.Model;

namespace SR.ModelImpl.Model
{
    public class DbModelObjectFactory : IDbModelObjectFactory
    {
        public ICourse CreateCourse(IUser coach)
        {
            return new Course(coach);
        }

        public IUser CreateUser(string username, string password, string firstName, string lastName, string email, string phoneNumber)
        {
            return new User(username, password, firstName, lastName, email, phoneNumber);
        }
    }
}
