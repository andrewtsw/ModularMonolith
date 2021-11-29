using Microsoft.Extensions.DependencyInjection;
using TCO.Finportal.Shared.Contract;
using TCO.SNT.EsfIntegration.Shared.Credential;

namespace TCO.Finportal.Shared.ContractImplementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSharedModuleContract(this IServiceCollection services)
        {
            services.AddScoped<ISharedModuleContract, SharedModuleContract>();
            services.AddScoped<IEsfCredentialManager, EsfCredentialManager>();

            return services;
        }
    }
}
