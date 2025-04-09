﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Application.ServiceContracts.Auth
{
    public interface IHashingService
    {

        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
