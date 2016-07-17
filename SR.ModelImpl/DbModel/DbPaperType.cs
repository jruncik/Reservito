using System;

namespace TV.ModelImpl.DbModel
{
    public class DbPaperType
    {
        public virtual Guid Id { get; set; } = Guid.Empty;
        public virtual int Color { get; set; } = 0;
        public virtual string Type { get; set; } = String.Empty;
    }
}
