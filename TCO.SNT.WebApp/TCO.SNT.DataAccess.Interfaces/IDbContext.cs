using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Domain.Entities;
using TCO.SNT.Entities;

namespace TCO.SNT.DataAccess.Interfaces
{
    public interface IDbContext
    {
        DbSet<Balance> Balances { get; }

        DbSet<Currency> Currencies { get; }

        DbSet<Country> Countries { get; }

        DbSet<FavouriteCountry> FavouriteCountries { get; }

        DbSet<FavouriteCurrency> FavouriteCurrencies { get; }

        DbSet<TaxpayerStore> TaxpayerStores { get; }

        DbSet<Product> Products { get; }

        DbSet<FavoriteProduct> FavoriteProducts { get; }

        DbSet<GroupTaxpayerStore> GroupTaxpayerStores { get; }

        #region UForms

        DbSet<UForm> UForms { get; }

        DbSet<UFormInfo> UFormInfos { get; }

        DbSet<UFormProduct> UFormProducts { get; }

        DbSet<UFormSender> UFormSenders { get; }

        DbSet<UFormRecipient> UFormRecipients { get; }

        #endregion

        #region Snt

        DbSet<Snt> Snts { get; }

        DbSet<SntInfo> SntInfos { get; }

        DbSet<SntConsignee> SntConsignees { get; }

        DbSet<SntConsignor> SntConsignors { get; }

        DbSet<SntContract> SntContracts { get; }

        DbSet<SntCustomer> SntCustomers { get; }

        DbSet<SntProduct> SntProducts { get; }

        DbSet<SntProductSet> SntProductSets { get; }

        DbSet<SntOilProduct> SntOilProducts { get; }

        DbSet<SntOilSet> SntOilSets { get; }

        DbSet<SntSeller> SntSellers { get; }

        DbSet<SntShippingInfo> SntShippingInfos { get; }

        #endregion

        Task<Settings> LoadSettingsAsync(CancellationToken cancellationToken);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        DbSet<ErrorCode> ErrorCodes { get; }

        Task MigrateAsync(CancellationToken cancellationToken);

        Task BulkInsertBalancesAsync(IList<Balance> balances, CancellationToken cancellationToken);

        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
    }
}
