using LawGuardian.Application.Features.Auth.Commands;
using LawGuardian.Application.RepositoryContracts.Auth;
using LawGuardian.Application.ServiceContracts.Auth;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Application.Features.Auth.Handlers
{

    //arg1 - is request type and arg2-is responsetype
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
    {

        private readonly IAuthRepositiry _authRepostory;
        private readonly IHashingService _hashingService;

        public RegisterUserCommandHandler(IAuthRepositiry authRepositiry,IHashingService hashingService)
        {
            _authRepostory = authRepositiry;
            _hashingService = hashingService;
        }
        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {

            

            throw new NotImplementedException();
        }
    }
}
    