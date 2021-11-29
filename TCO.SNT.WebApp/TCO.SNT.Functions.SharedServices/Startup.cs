using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TCO.Finportal.Infrastructure.Email.Smtp;
using TCO.Finportal.Infrastructure.KeyVault.Azure;
using TCO.Finportal.Shared.ContractImplementation;
using TCO.Finportal.Shared.DataAccess.SqlServer;
using TCO.Finportal.Shared.UseCases;
using TCO.SNT.Common.Options;
using TCO.SNT.DataAccess.SqlServer;
using TCO.SNT.EsfApi.Implementation.DependencyInjection;
using TCO.SNT.EsfApi.Implementation.Options;
using TCO.SNT.ExchangeRates.NationalBankKz;
using TCO.SNT.Infrastructure.Implementation;
using TCO.SNT.Infrastructure.Interfaces;
using TCO.SNT.Infrastructure.Interfaces.ReportBuilders.BalanceReport;
using TCO.SNT.UseCases;
using TCO.SNT.VStore.Implementation.DependencyInjection;
using TCO.SNT.VStore.Implementation.Options;

[assembly: FunctionsStartup(typeof(TCO.SNT.Functions.SharedServices.Startup))]

namespace TCO.SNT.Functions.SharedServices
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            AddOptions(builder);

            // Infrastructure: ESF
            builder.Services.AddVstoreServices();
            builder.Services.AddEsfApiServices();

            // Infrastructure: other
            builder.Services.AddInfrastructureServices();
            builder.Services.AddKeyVault();
            builder.Services.AddEmail();

            // Infrastructure: rates service requres HTTP client
            builder.Services.AddHttpClient();
            builder.Services.AddExchangeRatesService();

            // Host services
            builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

            var connectionString = GetConnectionString(builder.Services);

            // Shared module
            builder.Services.AddSharedModuleContract();
            builder.Services.AddSharedUseCases();
            builder.Services.AddSharedDataAccessSqlServer(connectionString);

            // SNT Module
            builder.Services.AddUseCases();
            builder.Services.AddDataAccessSqlServer(connectionString);
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

            builder.Services.AddOptions<VStoreOptions>()
                .Configure<IConfiguration>((settings, configuration) =>
                {
                    configuration.GetSection("VStoreOptions").Bind(settings);
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

            builder.Services.AddOptions<EmailOptions>()
               .Configure<IConfiguration>((settings, configuration) =>
               {
                   configuration.GetSection("EmailOptions").Bind(settings);
               });

            builder.Services.AddOptions<BalanceReportOptions>()
               .Configure<IConfiguration>((settings, configuration) =>
               {
                   configuration.GetSection("BalanceReportOptions").Bind(settings);
               });

            builder.Services.AddOptions<ExchangeRatesOptions>()
               .Configure<IConfiguration>((settings, configuration) =>
               {
                   configuration.GetSection("ExchangeRatesOptions").Bind(settings);
               });
        }
    }
}
