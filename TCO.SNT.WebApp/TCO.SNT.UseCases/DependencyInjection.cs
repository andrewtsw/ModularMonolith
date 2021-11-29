using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TCO.SNT.UseCases.ApplicationServices;

namespace TCO.SNT.UseCases
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            // MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Application services from UseCases
            services.AddScoped<TaxpayerStoreUserValidator>();
            services.AddScoped<ErrorHelper>();
            services.AddScoped<UserAccessService>();

            return services;
        }
    }
}
