using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TCO.EInvoicing.UseCases
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEInvoicingUseCases(this IServiceCollection services)
        {
            // MediatR
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
