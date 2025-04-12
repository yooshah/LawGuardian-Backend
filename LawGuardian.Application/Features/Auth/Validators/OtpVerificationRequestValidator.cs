using FluentValidation;
using LawGuardian.Application.Features.Auth.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Application.Features.Auth.Validators
{
    public class OtpVerificationRequestValidator:AbstractValidator<OtpVerificationRequest>
    {
        public OtpVerificationRequestValidator()
        {
            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("Email is required.")
               .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x=>x.Otp)
                .NotEmpty().WithMessage("OTP is required.")
                .Length(6).WithMessage("OTP must be exactly 6 digits.")
                .Matches("^[0-9]{6}$").WithMessage("OTP must be numeric.");


        }
    }
}
