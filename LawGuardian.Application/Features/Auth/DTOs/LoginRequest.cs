using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Application.Features.Auth.DTOs
{
    public class LoginRequest
    {
        public string Identifier { get; set; }  
        public string Password { get; set; }
    }
}
