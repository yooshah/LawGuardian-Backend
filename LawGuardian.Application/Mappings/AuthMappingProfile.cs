using AutoMapper;
using LawGuardian.Application.Features.Auth.DTOs;
using LawGuardian.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawGuardian.Application.Mappings
{
    public class AuthMappingProfile:Profile
    {

        public AuthMappingProfile()
        {
            CreateMap<RegisterRequest, User>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore()) 
                .ForMember(dest => dest.IsBlocked, opt => opt.MapFrom(src => false))
                .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => "Client")) 
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
        }
    }
}
