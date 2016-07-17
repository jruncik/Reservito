using System;

namespace SR.ModelImpl.Model
{
    [Flags]
    public enum FinishingJobFlag : UInt32
    {
        None   = 0x00000000,

        Numbering   = 0x00000001,
        Foldding    = 0x00000002,
        Perforation = 0x00000004,
        Cut         = 0x00000008,
        Bigovani    = 0x00000010,
        Assembling  = 0x00000020,
        Gluing      = 0x00000040,
        Needling    = 0x00000080,
        Lamination  = 0x00000100,
    }
}
