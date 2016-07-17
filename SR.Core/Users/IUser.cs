﻿using System;

namespace SR.Core.Users
{
    public interface IUser : IDbStorable
    {
        Guid Id { get; set; }
        String Username { get; set; }
        String Password { get; set; }
        bool IsBuiltIn { get; }
    }
}