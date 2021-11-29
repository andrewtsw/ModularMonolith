using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TCO.SNT.Infrastructure.Implementation.ReportBuilders;
using TCO.SNT.Infrastructure.Interfaces;
using TCO.SNT.Infrastructure.Interfaces.ReportBuilders.BalanceReport;

namespace TCO.SNT.Infrastructure.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IBalanceReportBuilder, BalanceReportBuilder>();
            services.AddScoped<ISntReportBuilder, SntReportBuilder>();
            services.AddScoped<IUFormReportBuilder, UFormReportBuilder>();

            services.AddScoped<IDateTime, MachineDateTime>();

            // TODO:
            // 1. Move report builders to a separate project
            // 2. Use default interfece implementation for IDateTime and remove this project.

            return services;
        }
    }
}
