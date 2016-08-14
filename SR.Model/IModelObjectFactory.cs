using SR.Core.Users;

namespace SR.Model
{
    public interface IModelObjectFactory
    {
        ICourse CreateCourse(IUser coach);
    }
}
