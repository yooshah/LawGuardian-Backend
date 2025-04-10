﻿using LawGuardian.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Application.ServiceContracts.Auth
{
    public interface IJwtService
    {
         string GenerateToken(User user);
    }
}
