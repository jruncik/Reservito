using System;

namespace SR.ModelImpl.DbModel
{
    public class DbRights
    {
        public virtual Guid Id { get; set; }
        public virtual Guid FkUser { get; set; }
        public virtual long Rights { get; set; }

        public DbRights()
        {
            Id = Guid.Empty;
            FkUser = Guid.Empty;
            Rights = 0;
        }
    }
}