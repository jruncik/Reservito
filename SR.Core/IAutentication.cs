﻿using System;

namespace SR.Core
{
    public interface IAutentication
    {
        void LogIn(String username, String password);
        void LogIn(SessionId sessionId, String username, String password);
    }
}