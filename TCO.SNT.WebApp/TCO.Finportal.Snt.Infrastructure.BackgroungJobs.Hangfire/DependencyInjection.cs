using Microsoft.Extensions.DependencyInjection;
using TCO.Finportal.Snt.Infrastructure.BackgroungJobs.Interfaces;

namespace TCO.Finportal.Snt.Infrastructure.BackgroungJobs.Hangfire
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBackgroundJobs(this IServiceCollection services)
        {
            services.AddScoped<IBackgroungJobService, BackgroungJobService>();

            return services;
        }
    }
}
