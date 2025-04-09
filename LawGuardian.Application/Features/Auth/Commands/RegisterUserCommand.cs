using LawGuardian.Application.Features.Auth.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Application.Features.Auth.Commands
{
    public record RegisterUserCommand (RegisterRequest RegisterRequest) : IRequest<string>;
}
    