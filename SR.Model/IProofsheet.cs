using System;
using SR.Core;

namespace SR.Model
{
    public interface IProofsheet : IDbStorable
    {
        Guid Id { get; set; }
        DateTime Time { get; set; }
        bool Passed { get; set; }
    }
}
