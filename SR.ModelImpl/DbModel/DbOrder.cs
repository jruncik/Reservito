using System;
using System.Drawing;

namespace TV.ModelImpl.DbModel
{
    public class DbOrder
    {
        public virtual Guid Id { get; set; } = Guid.Empty;
        public virtual DbContactPerson Contact { get; set; }
        public virtual string OrderType { get; set; } = String.Empty;
        public virtual DateTime OrderTime { get; set; } = DateTime.MinValue;
        public virtual DateTime FinishTime { get; set; } = DateTime.MinValue;
        public virtual int Priority { get; set; } = (int)TV.Model.Priority.Normal;
        public virtual DbPaperFormat Format { get; set; }
        public virtual int PageCount { get; set; }
        public virtual int Count { get; set; }
        public virtual int QuireCount { get; set; }
        public virtual int PrintColor { get; set; } = Color.Black.ToArgb();
        public virtual DbPaperType PaperType { get; set; }
        public virtual Guid Implementation { get; set; } = Guid.Empty;
        public virtual bool IsSpecimenSupplied { get; set; }
        public virtual bool IsPageCompositionSupplied { get; set; }
        public virtual DbProofsheet Proofsheet { get; set; }
        public virtual DbFinishingJob Finishing { get; set; }
        public virtual string Details { get; set; } = String.Empty;

        public DbOrder()
        {
            Id = Guid.Empty;
            OrderTime = DateTime.Now;
        }
    }
}
