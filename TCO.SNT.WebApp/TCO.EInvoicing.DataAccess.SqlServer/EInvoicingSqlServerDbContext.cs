using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.DataAccess.Interfaces;
using TCO.EInvoicing.Entities;
using TCO.EInvoicing.Entities.Jde;
using TCO.Finportal.Framework.DataAccess;
using TCO.Finportal.Framework.Domain.Entities;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.EInvoicing.DataAccess.SqlServer
{
    internal class EInvoicingSqlServerDbContext : DbContextBase<EInvoicingSqlServerDbContext>, IEInvoicingDbContext
    {
        public EInvoicingSqlServerDbContext(DbContextOptions<EInvoicingSqlServerDbContext> options,
            ICurrentUserService currentUserService, IDateTime dateTime)
            : base(options, currentUserService, dateTime)
        {
        }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceSeller> InvoiceSellers { get; set; }

        public DbSet<InvoiceCustomer> InvoiceCustomers { get; set; }

        public DbSet<InvoiceConsignee> InvoiceConsignees { get; set; }

        public DbSet<InvoiceConsignor> InvoiceConsignors { get; set; }

        public DbSet<InvoiceDeliveryTerm> InvoiceDeliveryTerms { get; set; }

        public DbSet<RelatedInvoice> RelatedInvoices { get; set; }

        public DbSet<InvoicePublicOffice> InvoicePublicOffices { get; set; }

        public DbSet<InvoiceProductSet> InvoiceProductSets { get; set; }

        public DbSet<InvoiceProduct> InvoiceProducts { get; set; }

        public DbSet<JdeArInvoice> JdeArInvoices { get; set; }

#if DEBUG

        // for local development only

        public EInvoicingSqlServerDbContext()
            : base(new DbContextOptionsBuilder<EInvoicingSqlServerDbContext>()
                .UseSqlServer("test")
                .Options, null, null)
        {
        }

#endif

        #region Settings

        public DbSet<EInvoicingSettings> Settings { get; set; }


        public async Task<EInvoicingSettings> LoadSettingsAsync(CancellationToken cancellationToken)
            => await Settings.SingleAsync(cancellationToken);

        #endregion

        #region Awp

        public DbSet<Awp> Awps { get; set; }

        #endregion

        public Task MigrateAsync(CancellationToken cancellationToken)
        {
            return Database.MigrateAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ei");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityTypeConfigurationHelper).Assembly);

            // TODO: move to entity configurator
            modelBuilder.Entity<MeasureUnit>()
                .ToTable("MeasureUnits", schema: "shared");

            modelBuilder.Entity<EInvoicingSettings>().HasData(new EInvoicingSettings
            {
                Id = 1,
                InvoicesUpdatesInboundLastEventDateUtc = new DateTimeOffset(1990, 1, 1, 0, 0, 0, TimeSpan.Zero),
                InvoicesUpdatesInboundLastInvoiceId = 0L,
                InvoicesUpdatesOutboundLastEventDateUtc = new DateTimeOffset(1990, 1, 1, 0, 0, 0, TimeSpan.Zero),
                InvoicesUpdatesOutboundLastInvoiceId = 0L,
                AwpUpdatesLastEventDateUtc = new DateTimeOffset(1990, 1, 1, 0, 0, 0, TimeSpan.Zero),
                AwpUpdatesLastAwpId = 0L,
                JdeArUpdatesLastDateUtc = new DateTimeOffset(2021, 1, 1, 0, 0, 0, TimeSpan.Zero)
            });
        }

        public Task BulkInsertEntitiesAsync<T>(IList<T> entities, CancellationToken cancellationToken)
            where T : class
        {
            if (!entities.Any())
                return Task.CompletedTask;

            return this.BulkInsertAsync(entities, cancellationToken: cancellationToken);
        }

        public Task BulkInsertInvoicesAsync(IList<Invoice> invoices, CancellationToken cancellationToken) =>
            this.BulkInsertAsync(invoices, config => config.IncludeGraph = true, cancellationToken: cancellationToken);

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken) =>
            Database.BeginTransactionAsync(cancellationToken);
    }
}
