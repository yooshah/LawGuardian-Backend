using FluentValidation;
using LawGuardian.Application.Features.Auth.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LawGuardian.Application.Features.Auth.Validators
{
    public class LoginRequestValidator:AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Identifier)
                .NotEmpty().WithMessage("Email or phone number is required.")
                .Must(BeAValidEmailOrPhone).WithMessage("Identifier must be a valid email or phone number.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,15}$")
                .WithMessage("Password must be 8-15 characters long and include at least one uppercase letter, one lowercase letter, one digit, and one special character.");

        }

        private bool BeAValidEmailOrPhone(string identifier)
        {
            if (string.IsNullOrWhiteSpace(identifier))
                return false;

            // Simple email and phone regex patterns
            var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            var phoneRegex = @"^\d{10}$";

            return Regex.IsMatch(identifier, emailRegex) || Regex.IsMatch(identifier, phoneRegex);
        }
    }
}
