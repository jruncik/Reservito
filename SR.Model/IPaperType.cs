using System;
using System.Drawing;
using TV.Core;

namespace TV.Model
{
    public interface IPaperType : IDbStorable
    {
        Guid Id { get; set; }
        Color Color { get; set; }
        string Type { get; set; }
    }
}
