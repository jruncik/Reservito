using System;

namespace SR.ModelImpl.DbModel
{
    public class DbFinishingJob
    {
        public virtual Guid Id { get; set; }
        public virtual Int32 Flags { get; set; }
        public virtual string Other { get; set; }

        public DbFinishingJob()
        {
            Id = Guid.Empty;
            Flags = 0;
            Other = String.Empty;
        }
    }
}
