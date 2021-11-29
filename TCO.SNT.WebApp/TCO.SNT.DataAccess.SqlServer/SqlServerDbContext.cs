using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.DataAccess;
using TCO.Finportal.Framework.Domain.Entities;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.Entities;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.SNT.DataAccess.SqlServer
{
    internal class SqlServerDbContext : DbContextBase<SqlServerDbContext>, IDbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options, 
            ICurrentUserService currentUserService, IDateTime dateTime)
            : base(options, currentUserService, dateTime)
        {
        }

#if DEBUG

        // for local development only

        public SqlServerDbContext()
            : base(new DbContextOptionsBuilder<SqlServerDbContext>()
                .UseSqlServer("test")
                .Options, null, null)
        {
        }

#endif

        public DbSet<Balance> Balances { get; set; }

        public DbSet<TaxpayerStore> TaxpayerStores { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }

        public DbSet<Settings> Settings { get; set; }

        public DbSet<GroupTaxpayerStore> GroupTaxpayerStores { get; set; }

        public DbSet<ErrorCode> ErrorCodes { get; set; }

        #region UForm

        public DbSet<UForm> UForms { get; set; }
        
        public DbSet<UFormInfo> UFormInfos { get; set; }

        public DbSet<UFormProduct> UFormProducts { get; set; }

        public DbSet<UFormSender> UFormSenders { get; set; }

        public DbSet<UFormRecipient> UFormRecipients { get; set; }

        #endregion

        #region Snt

        public DbSet<Snt> Snts { get; set; }

        public DbSet<SntInfo> SntInfos { get; set; }

        public DbSet<SntConsignee> SntConsignees { get; set; }

        public DbSet<SntConsignor> SntConsignors { get; set; }

        public DbSet<SntContract> SntContracts { get; set; }

        public DbSet<SntCustomer> SntCustomers { get; set; }

        public DbSet<SntProduct> SntProducts { get; set; }

        public DbSet<SntProductSet> SntProductSets { get; set; }

        public DbSet<SntOilProduct> SntOilProducts { get; set; }

        public DbSet<SntOilSet> SntOilSets { get; set; }

        public DbSet<SntSeller> SntSellers { get; set; }

        public DbSet<SntShippingInfo> SntShippingInfos { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<FavouriteCurrency> FavouriteCurrencies { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<FavouriteCountry> FavouriteCountries { get; set; }

        #endregion

        public async Task<Settings> LoadSettingsAsync(CancellationToken cancellationToken)
            => await Settings.SingleAsync(cancellationToken);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Automatically set Precision and Scale for all decimal properties 
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                // EF Core 3
                property.SetColumnType("decimal(18,2)");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityTypeConfigurationHelper).Assembly);

            modelBuilder.Entity<MeasureUnit>()
                .ToTable("MeasureUnits", schema: "shared");

            modelBuilder.Entity<Settings>().HasData(new Settings
            {
                Id = 1,
                GsvsLastChangeId = 0L,
                UFormUpdatesLastEventDateUtc = new DateTimeOffset(Entities.Settings.MinDate, TimeSpan.Zero),
                SntUpdatesLastSntId = 0L,
                SntUpdatesLastEventDateUtc = new DateTimeOffset(Entities.Settings.MinDate, TimeSpan.Zero)
            });
        }

        public Task MigrateAsync(CancellationToken cancellationToken)
        {
            return Database.MigrateAsync(cancellationToken);
        }

        public Task BulkInsertBalancesAsync(IList<Balance> balances, CancellationToken cancellationToken) =>
            this.BulkInsertAsync(balances, cancellationToken: cancellationToken);

        public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken) =>
            Database.BeginTransactionAsync(cancellationToken);
    }
}