using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TCO.Einvoicing.Jde.Implementation;
using TCO.Einvoicing.Jde.Interfaces;
using TCO.EInvoicing.DataAccess.SqlServer;
using TCO.EInvoicing.UseCases;
using TCO.Finportal.Infrastructure.KeyVault.Azure;
using TCO.Finportal.Shared.ContractImplementation;
using TCO.Finportal.Shared.DataAccess.SqlServer;
using TCO.Finportal.Shared.UseCases;
using TCO.SNT.Common.Options;
using TCO.SNT.EsfApi.Implementation.DependencyInjection;
using TCO.SNT.EsfApi.Implementation.Options;
using TCO.SNT.Infrastructure.Implementation;
using TCO.SNT.Infrastructure.Interfaces;

[assembly: FunctionsStartup(typeof(TCO.Finportal.Functions.EInvoicing.Startup))]

namespace TCO.Finportal.Functions.EInvoicing
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            AddOptions(builder);

            // Infrastructure: ESF integration 
            builder.Services.AddEsfApiServices();

            // Infrastructure: other
            builder.Services.AddInfrastructureServices();
            builder.Services.AddKeyVault();

            builder.Services.AddHttpClient();
            builder.Services.AddJdeIntegration();

            // Host services
            builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

            var connectionString = GetConnectionString(builder.Services);

            // Shared module
            builder.Services.AddSharedModuleContract();
            builder.Services.AddSharedUseCases();
            builder.Services.AddSharedDataAccessSqlServer(connectionString);

            // EI module
            builder.Services.AddEInvoicingUseCases();
            builder.Services.AddEInvoicingDataAccessSqlServer(connectionString);
        }

        private string GetConnectionString(IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var configuration = provider.GetRequiredService<IOptions<FunctionOptions>>();
            return configuration.Value.ConnectionString;
        }

        private static void AddOptions(IFunctionsHostBuilder builder)
        {
            builder.Services.AddOptions<FunctionOptions>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("FunctionOptions").Bind(settings);
                });

            builder.Services.AddOptions<KeyVaultOptions>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("KeyVaultOptions").Bind(settings);
                });

            builder.Services.AddOptions<CompanyOptions>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("CompanyOptions").Bind(settings);
                });

            builder.Services.AddOptions<EsfApiOptions>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("EsfApiOptions").Bind(settings);
                });

            builder.Services.AddOptions<JdeApimOptions>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("JdeApimOptions").Bind(settings);
                });
        }
    }
}
