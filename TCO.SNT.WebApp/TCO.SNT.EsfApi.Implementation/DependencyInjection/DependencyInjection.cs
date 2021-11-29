using Microsoft.Extensions.DependencyInjection;
using TCO.SNT.EsfApi.Implementation.Session;
using TCO.SNT.EsfApi.Interfaces;
using TCO.SNT.EsfApi.Interfaces.Awp;
using TCO.SNT.EsfApi.Interfaces.Invoices;
using TCO.SNT.EsfApi.Interfaces.Session;
using TCO.SNT.EsfApi.Interfaces.Snt;
using TCO.SNT.EsfApi.Interfaces.UploadInvoice;

namespace TCO.SNT.EsfApi.Implementation.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEsfApiServices(this IServiceCollection services)
        {
            // Session
            services.AddScoped<IEsfApiSessionFactory, EsfApiSessionFactory>();

            // Other services
            services.AddScoped<IEsfVersionService, EsfVersionService>();
            services.AddScoped<IEsfSntService, EsfSntService>();
            services.AddScoped<IEsfInvoiceService, EsfInvoiceService>();
            services.AddScoped<IEsfUploadInvoiceService, EsfUploadInvoiceService>();
            services.AddScoped<IEsfAwpService, EsfAwpService>();

            return services;
        }
    }
}
