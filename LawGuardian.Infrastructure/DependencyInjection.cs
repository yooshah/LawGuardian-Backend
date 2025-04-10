﻿using LawGuardian.Application.RepositoryContracts.Auth;
using LawGuardian.Application.ServiceContracts.Auth;
using LawGuardian.Application.ServiceContracts.Cloudinary;
using LawGuardian.Infrastructure.Persistence;
using LawGuardian.Infrastructure.Repository.Auth;
using LawGuardian.Infrastructure.Services.Auth;
using LawGuardian.Infrastructure.Services.CloudinaryCloud;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LawGuardian.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services,string connectionString)
        {

            services.AddDbContext<LawGuardianDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IHashingService, HashingService>();
            services.AddScoped<IAuthRepositiry, AuthRepository>();
            services.AddSingleton<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IJwtService, JwtService>();



            return services;
           
        }

    }
}
