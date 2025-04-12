using LawGuardian.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Application.RepositoryContracts.Auth
{
    public interface IEmailVerificationRepository
    {

        Task<bool> AddEmailVerificationAsync(EmailVerification emailVerification);

        Task<EmailVerification?> GetVerificationByEmailAndOtpAsync(string email, string otp);

        Task UpdateEmailVerificationAsync (EmailVerification emailVerification);
    }
}
