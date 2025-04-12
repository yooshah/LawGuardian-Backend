using FluentEmail.Core;
using LawGuardian.Application.ServiceContracts.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Infrastructure.Services.Auth
{
    public class EmailVerificationService : IEmailVerificationService
    {

        private readonly IFluentEmail _fluentEmail;
        public EmailVerificationService(IFluentEmail fluentEmail)
        {
            _fluentEmail= fluentEmail;
        }
        public string OtpGenerator()
        {

            var random=new Random();
            int otp = random.Next(100000, 1000000);
            
            return otp.ToString();
        }

        public async Task<bool> SendOtpEmailAsync(string email, string otp,string subject)
        {

            var result = await _fluentEmail
                .To(email)
                .Subject(subject)
                .Body($"<h3> Your Otp code is: {otp}</h3>", isHtml: true)
                .SendAsync();

            return result.Successful;
        }
    }
}
