using Microsoft.Extensions.DependencyInjection;
using TCO.SNT.ExchangeRates.Interfaces;

namespace TCO.SNT.ExchangeRates.NationalBankKz
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddExchangeRatesService(this IServiceCollection services)
        {
            services.AddScoped<IExchangeRatesService, ExchangeRatesService>();

            return services;
        }
    }
}
