using System;

namespace SR.ModelImpl.DbModel
{
    public class DbProofsheet
    {
        public virtual Guid Id { get; set; } = Guid.Empty;
        public virtual DateTime Time { get; set; } = DateTime.MinValue;
        public virtual bool Passed { get; set; }

        public DbProofsheet()
        {
            Id = Guid.Empty;
            Time = DateTime.MinValue;
        }
    }
}
