using LawGuardian.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Application.RepositoryContracts.Auth
{
    public interface IAuthRepositiry
    {
        Task<bool> RegisterNewUser(User user);
    }
}
