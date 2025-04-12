using LawGuardian.Application.Common.ApiResponse;
using LawGuardian.Application.Features.Auth.Commands;
using LawGuardian.Application.RepositoryContracts.Auth;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Application.Features.Auth.Handlers
{
    public class EmailVerificationCommandHandler : IRequestHandler<EmailVerificationCommand, string>
    {
        private readonly IEmailVerificationRepository _emailVerificationRepository;
        private readonly IAuthRepositiry _authRepositiry;

        public EmailVerificationCommandHandler(IEmailVerificationRepository emailVerificationRepository,IAuthRepositiry authRepositiry)
        {
            _emailVerificationRepository = emailVerificationRepository; 
            _authRepositiry = authRepositiry;
        }
        public async Task<string> Handle(EmailVerificationCommand request, CancellationToken cancellationToken)
        {

            var record=await _emailVerificationRepository.GetVerificationByEmailAndOtpAsync(request.Email,request.otp);

            if (record == null  ||  record.ExpireTime<DateTime.UtcNow || record.IsUsed)
            {
                throw new BadHttpRequestException("Invalid Otp");
            }
            if (record.IsValidated)
            {
                throw new BadHttpRequestException("Email already verified");
            }
            record.IsUsed = true;
            record.IsValidated=true;
            
            
            var userRecord=await _authRepositiry.GetUserByEmailAsync(request.Email);

            userRecord.IsEmailVerified = true;
            await _authRepositiry.UpdateUserEmailVerification(userRecord);


            return  "Email verified successfully!" ;
           
        }
    }
}
