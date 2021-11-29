using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TCO.EInvoicing.DataAccess.Interfaces;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.EInvoicing.DataAccess.SqlServer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEInvoicingDataAccessSqlServer(this IServiceCollection services, string connectionString)
        {
            services
                .AddDbContext<IEInvoicingDbContext, EInvoicingSqlServerDbContext>(
                    options => options.UseSqlServer(connectionString));

            services.AddScoped<IEInvoicingDbContextFactory, EInvoicingDbContextFactory>(serviceProvider => 
                new EInvoicingDbContextFactory(connectionString,
                    serviceProvider.GetRequiredService<ICurrentUserService>(),
                    serviceProvider.GetRequiredService<IDateTime>()));

            return services;
        }
    }
}
