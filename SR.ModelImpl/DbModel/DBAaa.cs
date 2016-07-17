using System;

namespace TV.ModelImpl.DbModel
{
    public class DbAaa
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DbBbb B { get; set; }

        public DbAaa()
        {
            Id = Guid.Empty;
        }
    }

}
