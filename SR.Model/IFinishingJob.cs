using System;
using SR.Core;

namespace SR.Model
{
    public interface IFinishingJob : IDbStorable
    {
        Guid Id { get; set; }
        bool Numbering { get; set; }
        bool Foldding { get; set; }
        bool Perforation { get; set; }
        bool Cut { get; set; }
        bool Bigovani { get; set; }
        bool Assembling { get; set; }
        bool Gluing { get; set; }
        bool Needling { get; set; }
        bool Lamination { get; set; }

        string Other { get; set; }
    }
}
