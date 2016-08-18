using SR.Core.Users;

namespace SR.Model
{
    public interface IDbModelObjectFactory
    {
        IUser CreateUser(string username, string password, string firstName, string lastName, string email, string phoneNumber);
        ICourse CreateCourse(IUser coach);
    }
}
