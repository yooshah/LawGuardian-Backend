using FluentValidation;
using LawGuardian.Application.Mappings;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LawGuardian.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {


            services.AddMediatR(cgf => cgf.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());



            return services;

        }

    }
}
