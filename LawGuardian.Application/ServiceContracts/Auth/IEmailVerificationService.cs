using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Application.ServiceContracts.Auth
{
    public interface IEmailVerificationService
    {
        string OtpGenerator();
        Task<bool> SendOtpEmailAsync(string email, string otp,string subject);
    }
}
