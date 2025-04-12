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
        private readonly IEmailVerificationService _emailVerificationService;
        private readonly IEmailVerificationRepository _emailVerificationRepository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IAuthRepositiry authRepositiry,IHashingService hashingService,IEmailVerificationService emailVerificationService,IEmailVerificationRepository emailVerificationRepository,IMapper mapper)
        {
            _authRepostory = authRepositiry;
            _hashingService = hashingService;
            _emailVerificationService=emailVerificationService;
            _emailVerificationRepository=emailVerificationRepository;
            _mapper = mapper;
        }
        public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {


            var isuserEmailAlreadyExist = await _authRepostory.GetUserByEmailAsync(request.RegisterRequest.Email);

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

            if(!isSaved)
            {
                return new RegisterUserResponse
                {
                    Success = false,
                    Message = "Registration failed"
                };
            }

            string otp = _emailVerificationService.OtpGenerator();


            EmailVerification emailVerification=new EmailVerification { Email=request.RegisterRequest.Email,Otp=otp,ExpireTime=DateTime.UtcNow.AddMinutes(5)};

            var isEmailVerificationCreated=await _emailVerificationRepository.AddEmailVerificationAsync(emailVerification);

            if(isEmailVerificationCreated)
            {
                await _emailVerificationService.SendOtpEmailAsync(request.RegisterRequest.Email,otp,"Email Verification");
            }
            
            return new RegisterUserResponse
            {
                Success = true,
                Message ="Successfully registered" 
            };



        }
    }
}
    