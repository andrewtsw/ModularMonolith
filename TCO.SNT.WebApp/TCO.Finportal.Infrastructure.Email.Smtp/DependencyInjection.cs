using Microsoft.Extensions.DependencyInjection;
using TCO.Finportal.Infrastructure.Email.Interfaces;

namespace TCO.Finportal.Infrastructure.Email.Smtp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEmail(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
