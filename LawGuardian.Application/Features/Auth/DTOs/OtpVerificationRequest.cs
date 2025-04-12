using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Application.Features.Auth.DTOs
{
    public class OtpVerificationRequest
    {
        public string Email { get; set; }

        public string Otp {  get; set; }
    }
}
