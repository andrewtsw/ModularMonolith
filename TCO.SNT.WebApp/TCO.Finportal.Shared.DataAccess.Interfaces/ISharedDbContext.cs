using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Domain.Entities;
using TCO.Finportal.Shared.Entities;

namespace TCO.Finportal.Shared.DataAccess.Interfaces
{
    public interface ISharedDbContext
    {
        DbSet<GroupRole> GroupRoles { get; }

        #region MeasureUnits

        DbSet<MeasureUnit> MeasureUnits { get; }

        DbSet<FavouriteMeasureUnit> FavouriteMeasureUnits { get; }

        #endregion

        #region EsfUserProfile

        DbSet<EsfUserProfile> EsfUserProfiles { get; }

        Task<EsfUserProfile> GetAuthEsfUserProfileAsync(Guid userId, CancellationToken cancellationToken);

        Task<EsfUserProfile> GetSignEsfUserProfileAsync(Guid userId, CancellationToken cancellationToken);

        Task<EsfUserProfile> GetOrCreateEsfUserProfileAsync(Guid userId, CancellationToken cancellationToken);

        #endregion

        Task<SharedSettings> LoadSettingsAsync(CancellationToken cancellationToken);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task MigrateAsync(CancellationToken cancellationToken);
    }
}
