using System;

namespace SR.ModelImpl.DbModel
{
    public class DbPaperFormat
    {
        public virtual Guid Id { get; set; }
        public virtual String Name { get; set; }
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public virtual bool IsBuildin { get; set; } = false;

        public DbPaperFormat()
        {
            Id = Guid.Empty;
            Name = String.Empty;
        }
    }
}