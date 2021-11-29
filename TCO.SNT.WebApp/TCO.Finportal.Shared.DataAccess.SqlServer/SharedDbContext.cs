using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.DataAccess;
using TCO.Finportal.Framework.Domain.Entities;
using TCO.Finportal.Shared.DataAccess.Interfaces;
using TCO.Finportal.Shared.Entities;
using TCO.Finportal.Shared.Entities.Exceptions;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.Finportal.Shared.DataAccess.SqlServer
{
    internal class SharedDbContext : DbContextBase<SharedDbContext>, ISharedDbContext
    {
        public SharedDbContext(DbContextOptions<SharedDbContext> options,
            ICurrentUserService currentUserService, IDateTime dateTime)
            : base(options, currentUserService, dateTime)
        {
        }

#if DEBUG

        // for local development only

        public SharedDbContext()
            : base(new DbContextOptionsBuilder<SharedDbContext>()
                .UseSqlServer("test")
                .Options, null, null)
        {
        }

#endif

        public Task MigrateAsync(CancellationToken cancellationToken)
        {
            return Database.MigrateAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("shared");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityTypeConfigurationHelper).Assembly);

            // TODO: move to entity configurator
            modelBuilder.Entity<MeasureUnit>()
                .ToTable("MeasureUnits", schema: "shared");

            modelBuilder.Entity<SharedSettings>().HasData(new SharedSettings
            {
                Id = 1,
                MeasureUnitsLastEventDateUtc = new DateTimeOffset(1990, 1, 1, 0, 0, 0, TimeSpan.Zero),
            });
        }

        public DbSet<GroupRole> GroupRoles { get; set; }

        #region MeasureUnits

        public DbSet<MeasureUnit> MeasureUnits { get; set; }

        public DbSet<FavouriteMeasureUnit> FavouriteMeasureUnits { get; set; }

        #endregion

        #region EsfUserProfile

        public DbSet<EsfUserProfile> EsfUserProfiles { get; set; }

        public async Task<EsfUserProfile> GetAuthEsfUserProfileAsync(Guid userId, CancellationToken cancellationToken)
        {
            var profile = await EsfUserProfiles.FindAsync(new object[] { userId }, cancellationToken);

            if (profile == null || !profile.ReadyForAuth())
            {
                throw new InvalidEsfProfileException();
            }

            return profile;
        }

        public async Task<EsfUserProfile> GetSignEsfUserProfileAsync(Guid userId, CancellationToken cancellationToken)
        {
            var profile = await GetAuthEsfUserProfileAsync(userId, cancellationToken);

            if (!profile.ReadyForSign())
            {
                throw new InvalidEsfProfileException();
            }

            return profile;
        }

        public async Task<EsfUserProfile> GetOrCreateEsfUserProfileAsync(Guid userId, CancellationToken cancellationToken)
        {
            var profile = await EsfUserProfiles.FindAsync(new object[] { userId }, cancellationToken);

            if (profile == null)
            {
                profile = EsfUserProfile.CreateEmpty(userId);
                EsfUserProfiles.Add(profile);
            }

            return profile;
        }

        #endregion

        #region Settings 

        public DbSet<SharedSettings> Settings { get; set; }

        public async Task<SharedSettings> LoadSettingsAsync(CancellationToken cancellationToken)
            => await Settings.SingleAsync(cancellationToken);

        #endregion
    }
}
