using System.Collections.Generic;

namespace TV.ModelImpl.Model
{
    public class Organisation
    {
        public string Name
        {
            get; set;
        }
        public IList<ContactPerson> ContactPersons
        {
            get; private set;
        }
    }
}