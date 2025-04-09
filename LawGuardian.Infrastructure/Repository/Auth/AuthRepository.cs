using LawGuardian.Application.RepositoryContracts.Auth;
using LawGuardian.Domain.Entities;
using LawGuardian.Infrastructure.Persistence;
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
    }
}
