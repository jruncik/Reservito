using System;

namespace SR.ModelImpl.DbModel
{
    public class DbRights : ICloneable
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

        public DbRights(DbRights other)
        {
            Id = other.Id;
            FkUser = other.FkUser;
            Rights = other.Rights;
        }

        public virtual object Clone()
        {
            return new DbRights(this);
        }

    }
}