using Microsoft.Extensions.DependencyInjection;
using TCO.Einvoicing.Jde.Interfaces;

namespace TCO.Einvoicing.Jde.Implementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddJdeIntegration(this IServiceCollection services)
        {
            services.AddScoped<IJdeApimService, JdeApimService>();

            return services;
        }
    }
}
