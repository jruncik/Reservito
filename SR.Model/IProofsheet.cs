using System;
using TV.Core;

namespace TV.Model
{
    public interface IProofsheet : IDbStorable
    {
        Guid Id { get; set; }
        DateTime Time { get; set; }
        bool Passed { get; set; }
    }
}
