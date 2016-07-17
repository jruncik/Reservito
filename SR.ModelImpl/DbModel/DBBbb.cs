using System;

namespace TV.ModelImpl.DbModel
{
    public class DbBbb
    {
        public virtual Guid Id { get; set; }
        public virtual int Age { get; set; }

        public DbBbb()
        {
            Id = Guid.Empty;
        }
    }
}
