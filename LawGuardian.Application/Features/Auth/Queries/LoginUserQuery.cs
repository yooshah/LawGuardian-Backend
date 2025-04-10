using LawGuardian.Application.Features.Auth.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Application.Features.Auth.Queries
{
    public  record LoginUserQuery(string Identifier, string password) : IRequest<LoginUserResponse>;
   
}
