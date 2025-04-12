using LawGuardian.Application.Common.ApiResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Application.Features.Auth.Commands
{
    public record EmailVerificationCommand(string Email,string otp):IRequest<string>;
}
