using LawGuardian.Application.Features.Auth.DTOs;
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
        public AuthController()
        {


            
        }

        public async Task <IActionResult> Register(RegisterRequest registerRequest)
        {

        }
    }
}
