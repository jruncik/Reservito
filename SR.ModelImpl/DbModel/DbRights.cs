using System;

using SR.Core;

namespace SR.ModelImpl.DbModel
{
    public class DbRights : IDbCloneable
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

        public virtual T Clone<T>() where T : class
        {
            return (T)(object)(new DbRights(this));
        }

    }
}