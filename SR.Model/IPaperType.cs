using System;
using System.Drawing;
using SR.Core;

namespace SR.Model
{
    public interface IPaperType : IDbStorable
    {
        Guid Id { get; set; }
        Color Color { get; set; }
        string Type { get; set; }
    }
}
