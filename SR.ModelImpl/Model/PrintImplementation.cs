using System;
using TV.Model;

namespace TV.ModelImpl.Model
{
    public class PrintImplementation : IPrintImplementation
    {
        public Guid Id
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Reload()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}