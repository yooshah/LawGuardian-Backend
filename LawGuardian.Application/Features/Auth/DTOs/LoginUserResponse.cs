using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Application.Features.Auth.DTOs
{
    public class LoginUserResponse
    {

        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public string AccessToken { get; set; }


    }
}
