using System;

namespace SR.Core.Log
{
    [Flags]
    public enum LogLevel
    {
        Debug       = 0x01,
        Info        = 0x03,
        Warning     = 0x07,
        Error       = 0x0F,
        Critical    = 0x1F,
    }
}