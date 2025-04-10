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
    public class AuthRepository : IAuthRepositiry
    {

        private readonly LawGuardianDbContext _context;

        public AuthRepository(LawGuardianDbContext context)
        {
            _context = context;
        }

       

        public async Task<bool> RegisterNewUser(User user)
        {

            await _context.Users.AddAsync(user);

            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<User?> UserEmailAlreadyExistAsync(string email)
        {

            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User?> GetUserByPhoneAsync(string phoneNumber)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Phone == phoneNumber);
           
        }

        public async Task<User?> GetUserByEmailOrPhoneAsync(string identifier)
        {
            return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == identifier || u.Phone == identifier);
        }
    }
}
