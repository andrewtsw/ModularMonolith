using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TCO.Finportal.Shared.DataAccess.Interfaces;

namespace TCO.Finportal.Shared.DataAccess.SqlServer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSharedDataAccessSqlServer(this IServiceCollection services, string connectionString)
        {
            services
                .AddDbContext<ISharedDbContext, SharedDbContext>(
                    options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
