using SR.Core.Users;

using SR.Model;

namespace SR.ModelImpl.Model
{
    public class ModelObjectFactory : IModelObjectFactory
    {
        public ICourse CreateCourse(IUser coach)
        {
            return new Course(coach);
        }
    }
}
