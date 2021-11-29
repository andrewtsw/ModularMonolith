using Microsoft.Extensions.DependencyInjection;
using TCO.SNT.Contract;

namespace TCO.SNT.ContractImplementation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSntModuleContract(this IServiceCollection services)
        {
            services.AddScoped<ISntModuleContract, SntModuleContract>();            

            return services;
        }
    }    
}
