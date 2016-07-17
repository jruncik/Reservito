using System;
using TV.Core;

namespace TV.Model
{
    public interface IPrintImplementation : IDbStorable
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
