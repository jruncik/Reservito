using System;
using SR.Core;

namespace SR.Model
{
    public interface IPrintImplementation : IDbStorable
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
