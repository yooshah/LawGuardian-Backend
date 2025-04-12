using LawGuardian.Application.RepositoryContracts.Auth;
using LawGuardian.Domain.Entities;
using LawGuardian.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Infrastructure.Repository.Auth
{
    public class EmailVerificationRepository : IEmailVerificationRepository
    {

        private readonly LawGuardianDbContext _context;

        public EmailVerificationRepository(LawGuardianDbContext context)
        {
            _context= context;
        }
        public async  Task<bool> AddEmailVerificationAsync(EmailVerification emailVerification)
        {
            await _context.EmailVerifications.AddAsync(emailVerification);

            return await _context.SaveChangesAsync()>0;
        }

        public async Task<EmailVerification?> GetVerificationByEmailAndOtpAsync(string email, string otp)
        {    
            return await _context.EmailVerifications.FirstOrDefaultAsync(x=>x.Email==email &&  x.Otp==otp);    

        }

        public async Task UpdateEmailVerificationAsync(EmailVerification emailVerification)
        {
             _context.EmailVerifications.Update(emailVerification);
            await _context.SaveChangesAsync();
        }
    }
}
