using Microsoft.Extensions.DependencyInjection;
using TCO.Finportal.Infrastructure.MsGraph.Interfaces;

namespace TCO.Finportal.Infrastructure.MsGraph.Sdk
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMsGraph(this IServiceCollection services)
        {
            services.AddScoped<IMsGraphService, MsGraphService>();

            // TODO: Get rid of Microsoft.Graph.Auth library because it is no longer supported

            return services;
        }
    }
}
