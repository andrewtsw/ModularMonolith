using Microsoft.Extensions.DependencyInjection;
using TCO.SNT.VStore.Interfaces;

namespace TCO.SNT.VStore.Implementation.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddVstoreServices(this IServiceCollection services)
        {
            services.AddScoped<ITaxpayerStoreService, TaxpayerStoreService>();
            services.AddScoped<IVstoreBalanceService, VstoreBalanceService>();
            services.AddScoped<IVstoreDictionariesService, VstoreDictionariesService>();
            services.AddScoped<IVstoreUFormService, VstoreUFormService>();
            services.AddScoped<IVstoreSessionFactory, VstoreSessionFactory>();
            services.AddScoped<IVstoreVersionService, VstoreVersionService>();

            return services;
        }
    }
}
