using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TCO.Finportal.Shared.ApplicationServices;

namespace TCO.Finportal.Shared.UseCases
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSharedUseCases(this IServiceCollection services)
        {
            // MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Application services
            services.AddScoped<RolesService>();

            return services;
        }
    }
}
