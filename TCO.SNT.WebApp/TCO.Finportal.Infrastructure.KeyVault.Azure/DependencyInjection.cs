using Microsoft.Extensions.DependencyInjection;
using TCO.Finportal.Infrastructure.KeyVault.Interfaces;

namespace TCO.Finportal.Infrastructure.KeyVault.Azure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddKeyVault(this IServiceCollection services)
        {
            services.AddScoped<IKeyVaultService, KeyVaultService>();
           
            return services;
        }
    }
}
