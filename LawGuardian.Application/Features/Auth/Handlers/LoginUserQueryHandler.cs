using LawGuardian.Application.Features.Auth.DTOs;
using LawGuardian.Application.Features.Auth.Queries;
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
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginUserResponse>
    {

        private readonly IAuthRepositiry _authRepositiry;
        private readonly IHashingService _hashingService;
        private readonly IJwtService _jwtService;
        public LoginUserQueryHandler(IAuthRepositiry authRepositiry,IHashingService hashingService, IJwtService jwtService)
        {
            _authRepositiry = authRepositiry;
            _jwtService = jwtService;
            _hashingService = hashingService;
        }
        public async Task<LoginUserResponse> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {

            var result = await _authRepositiry.GetUserByEmailOrPhoneAsync(request.Identifier);
            if (result == null)
            {
                return new LoginUserResponse {IsSuccess=false, Message="Invalid user data! Email Or Phone Number Not Found"};
            }

            var checkPassword= _hashingService.VerifyPassword(request.password,result.Password);
            if (!checkPassword)
            {
                return new LoginUserResponse {IsSuccess=false, Message = "Incorrect password!" };
            }

            var accessToken = _jwtService.GenerateToken(result);

            return new LoginUserResponse {IsSuccess=true, AccessToken = accessToken,Message="SuccessfullyLogin" };

          
        }
    }
}
