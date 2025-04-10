using AutoMapper;
using LawGuardian.Application.Features.Auth.Commands;
using LawGuardian.Application.Features.Auth.DTOs;
using LawGuardian.Application.RepositoryContracts.Auth;
using LawGuardian.Application.ServiceContracts.Auth;
using LawGuardian.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Application.Features.Auth.Handlers
{

    //arg1 - is request type and arg2-is responsetype
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {

        private readonly IAuthRepositiry _authRepostory;
        private readonly IHashingService _hashingService;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IAuthRepositiry authRepositiry,IHashingService hashingService,IMapper mapper)
        {
            _authRepostory = authRepositiry;
            _hashingService = hashingService;
            _mapper = mapper;
        }
        public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {


            var isuserEmailAlreadyExist = await _authRepostory.UserEmailAlreadyExistAsync(request.RegisterRequest.Email);

            if (isuserEmailAlreadyExist != null)
            {
                return new RegisterUserResponse
                {
                    Success = false,
                    Message = "Email already exists"
                };

            }

            var isPhoneNumberAlreadyExist=await _authRepostory.GetUserByPhoneAsync(request.RegisterRequest.Phone);
            if (isPhoneNumberAlreadyExist != null)
            {
                return new RegisterUserResponse
                {
                    Success = false,
                    Message = "Phone Number already exists"
                };
            }
            var hashedpassword =   _hashingService.HashPassword(request.RegisterRequest.Password);

            User registerData= _mapper.Map<User>(request.RegisterRequest);

            registerData.Password = hashedpassword;


            var isSaved = await _authRepostory.RegisterNewUser(registerData);

            return new RegisterUserResponse
            {
                Success = isSaved,
                Message = isSaved ? "Successfully registered" : "Registration failed"
            };



        }
    }
}
    