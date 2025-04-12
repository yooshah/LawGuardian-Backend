using LawGuardian.Application.RepositoryContracts.Auth;
using LawGuardian.Application.ServiceContracts.Auth;
using LawGuardian.Application.ServiceContracts.Cloudinary;
using LawGuardian.Infrastructure.Persistence;
using LawGuardian.Infrastructure.Repository.Auth;
using LawGuardian.Infrastructure.Services.Auth;
using LawGuardian.Infrastructure.Services.CloudinaryCloud;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Net.Mail;

namespace LawGuardian.Infrastructure
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services,string connectionString)
        {
            var emailPassword = Environment.GetEnvironmentVariable("EMAIL-PASSWORD") ?? throw new InvalidOperationException("Email password not configured");

            services.AddDbContext<LawGuardianDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddFluentEmail("lawguardian.official@gmail.com")
                .AddRazorRenderer()
                .AddSmtpSender(new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("lawguardian.official@gmail.com", emailPassword),
                    EnableSsl = true
                });

            services.AddScoped<IHashingService, HashingService>();
            services.AddScoped<IAuthRepositiry, AuthRepository>();
            services.AddSingleton<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IEmailVerificationRepository, EmailVerificationRepository>();
            services.AddTransient<IEmailVerificationService, EmailVerificationService>();


            return services;
           
        }

    }
}
