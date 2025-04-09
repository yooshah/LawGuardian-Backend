﻿using BCrypt.Net;
using LawGuardian.Application.ServiceContracts.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Infrastructure.Services.Auth
{
    public class HashingService : IHashingService
    {
        public string HashPassword(string password)
        {
            return  BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
