using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TCO.SNT.DataAccess.Interfaces;

namespace TCO.SNT.DataAccess.SqlServer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataAccessSqlServer(this IServiceCollection services, string connectionString)
        {
            services
                .AddDbContext<IDbContext, SqlServerDbContext>(options => options.UseSqlServer(connectionString));
            
            return services;
        }
    }
}
