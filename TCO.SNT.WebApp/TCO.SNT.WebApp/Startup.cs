using Chevron.Identity.AspNet.Client;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using NSwag;
using NSwag.Generation.Processors.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using TCO.Einvoicing.Jde.Implementation;
using TCO.Einvoicing.Jde.Interfaces;
using TCO.EInvoicing.DataAccess.SqlServer;
using TCO.EInvoicing.UseCases;
using TCO.Finportal.Infrastructure.Email.Smtp;
using TCO.Finportal.Infrastructure.KeyVault.Azure;
using TCO.Finportal.Infrastructure.MsGraph.Sdk;
using TCO.Finportal.Shared.ContractImplementation;
using TCO.Finportal.Shared.DataAccess.SqlServer;
using TCO.Finportal.Shared.UseCases;
using TCO.Finportal.Snt.Infrastructure.BackgroungJobs.Hangfire;
using TCO.SNT.Common;
using TCO.SNT.Common.Options;
using TCO.SNT.ContractImplementation;
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
using TCO.SNT.WebApp.Initialization;
using TCO.SNT.WebApp.Middlewares;
using TCO.SNT.WebApp.Services;

namespace TCO.SNT.WebApp
{
    public class Startup
    {
        private readonly string _frontendCorsPolicy = "FrontendCorsPolicy";
        private readonly TimeSpan _policyPreflightMaxAge = TimeSpan.FromSeconds(2520);

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // KeyVault options are stored in the appsettings file.
            // Because we need KeyVault.Url to load other options from this KeyVault.
            services.Configure<KeyVaultOptions>(Configuration.GetSection("KeyVault"));

            // All other settings are loaded from the KeyVault.
            services.Configure<CompanyOptions>(Configuration.GetSection("CompanyOptions"));
            services.Configure<VStoreOptions>(Configuration.GetSection("VStoreOptions"));
            services.Configure<EsfApiOptions>(Configuration.GetSection("EsfApiOptions"));
            services.Configure<EmailOptions>(Configuration.GetSection("EmailOptions"));
            services.Configure<SntReportOptions>(Configuration.GetSection("SntReportOptions"));
            services.Configure<UFormReportOptions>(Configuration.GetSection("UFormReportOptions"));
            services.Configure<BalanceReportOptions>(Configuration.GetSection("BalanceReportOptions"));
            services.Configure<ExchangeRatesOptions>(Configuration.GetSection("ExchangeRatesOptions"));
            services.Configure<JdeApimOptions>(Configuration.GetSection("JdeApimOptions"));

            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseSqlServerStorage(Configuration.GetConnectionString("ConnectionString")));

            // Add the processing server as IHostedService
            services.AddHangfireServer();

            // Shared module
            services.AddSharedDataAccessSqlServer(Configuration.GetConnectionString("ConnectionString"));
            services.AddSharedUseCases();
            services.AddSharedModuleContract();

            // Snt module
            services.AddDataAccessSqlServer(Configuration.GetConnectionString("ConnectionString"));
            services.AddUseCases();
            services.AddBackgroundJobs();
            services.AddSntModuleContract();

            // EInvoicing module
            services.AddEInvoicingDataAccessSqlServer(Configuration.GetConnectionString("ConnectionString"));
            services.AddEInvoicingUseCases();

            // Infrastructure can be shared between modules
            services.AddInfrastructureServices();
            services.AddKeyVault();
            services.AddEmail();
            services.AddMsGraph();

            // ExchangeRates is infrastructure service. And it requres HttpClient
            services.AddHttpClient();
            services.AddExchangeRatesService();
            services.AddJdeIntegration();

            // Snt integration services can be shared between modules
            services.AddVstoreServices();
            services.AddEsfApiServices();

            // Web host services
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ICurrentUserNameableService, CurrentUserService>();
            services.AddAsyncInitializer<DatabaseInitializer>();

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddHttpContextAccessor();
            services.AddApplicationInsightsTelemetry();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .WithOrigins(Configuration.GetSection("FrontendOrigin").Get<string[]>())
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithExposedHeaders("Content-Disposition") // used for getting name of downloaded file on UI
                        .SetPreflightMaxAge(_policyPreflightMaxAge);
                });

                options.AddPolicy(_frontendCorsPolicy, builder =>
                {
                    builder
                        .WithOrigins(Configuration.GetSection("FrontendOrigin").Get<string[]>())
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .WithExposedHeaders("Content-Disposition") // used for getting name of downloaded file on UI
                        .SetPreflightMaxAge(_policyPreflightMaxAge);
                });
            });

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            services.AddSwaggerDocument(doc =>
            {
                doc.AddSecurity("bearer", new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.OAuth2,
                    Flow = OpenApiOAuth2Flow.Implicit,
                    Flows = new OpenApiOAuthFlows()
                    {
                        Implicit = new OpenApiOAuthFlow()
                        {
                            Scopes = new Dictionary<string, string>
                            {
                                  {  Configuration["AzureAD:ApiScope"], "user_impersonation"}
                            },
                            AuthorizationUrl = Configuration["AzureAD:AuthorizationUrl"]
                        },
                    }
                });

                doc.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("bearer"));
            });

            services.AddRouting();
            //services.AddCal(Configuration, true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseAuthentication();
            //app.UseCalMiddleware();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                IdentityModelEventSource.ShowPII = true;
            }

            app.UseCustomExceptionHandler();

            app.UseRouting();

            if (env.IsDevelopment())
            {
                app.UseCors();
            }
            else
            {
                app.UseCors(_frontendCorsPolicy);
            }

            //app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHangfireDashboard();
            });

            app.UseHttpsRedirection();

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en"),
                SupportedCultures = GlobalConst.SupportedCultures,
                SupportedUICultures = GlobalConst.SupportedCultures
            });

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
