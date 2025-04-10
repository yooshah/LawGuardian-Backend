using LawGuardian.Application.ServiceContracts.Auth;
using LawGuardian.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Infrastructure.Repository.Auth
{
    public class JwtService : IJwtService
    {

        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(User user)
        {

            var secretKey = _configuration["JWT-SECRET-KEY"]
      ?? throw new InvalidOperationException("JWT-SECRET-KEY is missing from configuration.");

            var issuer = _configuration["JWT-ISSUER"]
                ?? throw new InvalidOperationException("JWT-ISSUER is missing from configuration.");

            var audience = _configuration["JWT-AUDIENCE"]
                ?? throw new InvalidOperationException("JWT-AUDIENCE is missing from configuration.");

            var expiryStr = _configuration["JWT-EXPIRE-HOUR"]
                ?? throw new InvalidOperationException("JWT-EXPIRE-HOUR is missing from configuration.");

            if (!int.TryParse(expiryStr, out var expiryInHours))
                throw new InvalidOperationException("JWT-EXPIRE-HOUR is not a valid number.");


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
               {

                    new Claim(ClaimTypes.Role, user.UserType.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // JwtId
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Email, user.Email)

                };

            var token = new JwtSecurityToken(
                  issuer: issuer,
                  audience: audience,
                  claims: claims,
                  expires: DateTime.UtcNow.AddHours(expiryInHours),
                  signingCredentials: credentials
              );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
          
    }


}
    

