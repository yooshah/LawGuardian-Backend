using LawGuardian.Application.Features.Auth.Commands;
using LawGuardian.Application.Features.Auth.DTOs;
using LawGuardian.Application.Features.Auth.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LawGuardian.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ISender _sender;
        public AuthController(ISender sender)
        {

            _sender= sender;
            
        }

        [HttpPost("client/register")]
        public async Task <IActionResult> Register([FromBody] RegisterRequest registerRequest ,CancellationToken cancellationToken)
        {

            if (registerRequest == null)
            {
                return BadRequest( new RegisterUserResponse { Message = "Invalid registration data", Success = false });
            }
          
            var result=await _sender.Send(new RegisterUserCommand(registerRequest), cancellationToken);

           
            if(!result.Success)
            {
                return Conflict(result);
            }

            return Ok(result);

        }


        [HttpPost("client/login")]

        public async Task <IActionResult> UserLogin(LoginRequest loginRequest, CancellationToken cancellationToken)
        {

            if (loginRequest == null)
            {
                return BadRequest(new LoginUserResponse { Message="Invalid Login Data" });

            }

            var result = await _sender.Send(new LoginUserQuery(loginRequest.Email, loginRequest.Password),cancellationToken);

            if (!result.IsSuccess)
            {
                return BadRequest(result); 
            }

            return Ok(new{ Message=result});
        }


        [HttpPost("EmailVerify-otp")]
        public async Task<IActionResult> VerfyEmailByOtp(OtpVerificationRequest otpVerificationRequest)
        {
            if(otpVerificationRequest == null)
            {
                return BadRequest("Invalid Data");
            }
            var result = await _sender.Send(new EmailVerificationCommand(otpVerificationRequest.Email, otpVerificationRequest.Otp));

            return Ok(result);

        }

        
        


    }
}
