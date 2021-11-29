using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Domain.Entities;
using TCO.Finportal.Framework.UseCases;
using TCO.Finportal.Framework.UseCases.Extensions;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.Entities;
using TCO.SNT.UseCases.Shared;

namespace TCO.SNT.UseCases.Extentions
{
    public static class DbContextExtensions
    {
        public static async Task<IDictionary<int, TaxpayerStore>> GetTaxpayerStoresDictByIdAsync(this IDbContext context,
           CancellationToken cancellationToken)
        {
            return await context.TaxpayerStores.ToDictionaryAsync(x => x.Id, cancellationToken);
        }

        public static async Task<IDictionary<long, TaxpayerStore>> GetTaxpayerStoresDictByExternalIdAsync(this IDbContext context,
            CancellationToken cancellationToken)
        {
            return await context.TaxpayerStores.ToDictionaryAsync(x => x.ExternalId, cancellationToken);
        }

        public static IQueryable<UForm> AddUFormIncludes(this IQueryable<UForm> query)
        {
            // !!! Before change make sure it will not affect references

            return query
                .Include(f => f.UFormInfo)
                .Include(f => f.Sender)
                .Include(f => f.Recipient)
                .Include(f => f.Products)
                    .ThenInclude(q => q.Balance)
                .Include(f => f.Products)
                    .ThenInclude(m => m.MeasureUnit)
                .Include(f => f.SourceProducts)
                    .ThenInclude(q => q.Balance);
        }

        public static async Task<UForm> LoadUFormByIdAsync(this IDbContext context,
            int id, CancellationToken cancellationToken)
        {
            return await context.UForms
                .AddUFormIncludes()
                .SingleOrExceptionAsync(x => x.Id == id, cancellationToken);
        }

        public static async Task<UForm> TryLoadUFormByExternalIdAsync(this IQueryable<UForm> query,
    long externalId, CancellationToken cancellationToken)
        {
            return await query
                .SingleOrDefaultAsync(x => x.ExternalId == externalId, cancellationToken);
        }

        public static IQueryable<Entities.Snt> AddAllSntIncludes(this IQueryable<Entities.Snt> query)
        {
            return query
                .Include(x => x.SntInfo)
                .Include(x => x.AcceptanceGoodsInfo)
                .Include(x => x.DocumentInfo)
                .Include(x => x.OgdMarksInfo)
                .Include(x => x.Seller)
                .Include(x => x.Customer)
                .Include(x => x.Consignee)
                .Include(x => x.Consignor)
                .Include(x => x.ShippingInfo)
                .Include(x => x.Contract)
                .Include(x => x.CarCargoInfo)
                .Include(x => x.Products)
                    .ThenInclude(x => x.Balance)
                    .ThenInclude(x => x.TaxpayerStore)
                .Include(x => x.Products)
                    .ThenInclude(x => x.MeasureUnit)
                .Include(x => x.ProductSet)
                .Include(x => x.OilProducts)
                    .ThenInclude(x => x.MeasureUnit)
                .Include(x => x.OilProducts)
                    .ThenInclude(x => x.Balance)
                    .ThenInclude(x => x.TaxpayerStore)
                .Include(x => x.OilSet);
        }

        public static async Task<Entities.Snt> LoadSntByIdAsync(this IDbContext context, int id, CancellationToken cancellationToken)
        {
            return await context.Snts
                .AddAllSntIncludes()
                .SingleOrExceptionAsync(x => x.Id == id, cancellationToken);
        }

        public static async Task<Entities.Snt> LoadSntByRegistrationNumberAsync(this IDbContext context, string registrationNumber, CancellationToken cancellationToken)
        {
            return await context.Snts
                .AddAllSntIncludes()
                .SingleOrExceptionAsync(x => x.SntInfo.RegistrationNumber == registrationNumber, cancellationToken);
        }

        public static async Task<Entities.Snt> LoadSntInfoByRegistrationNumberAsync(this IDbContext context, string registrationNumber, CancellationToken cancellationToken)
        {
            return await context.Snts
                .Include(x => x.SntInfo)
                .Include(x => x.AcceptanceGoodsInfo)
                .Include(x => x.DocumentInfo)
                .Include(x => x.OgdMarksInfo)
                .SingleOrExceptionAsync(x => x.SntInfo.RegistrationNumber == registrationNumber, cancellationToken);
        }

        public static async Task<Entities.Snt> LoadSntByExternalIdAsync(this IDbContext context, long externalId, CancellationToken cancellationToken)
        {
            return await context.Snts
                .AddAllSntIncludes()
                .SingleOrExceptionAsync(x => x.ExternalId == externalId, cancellationToken);
        }

        public static async Task<Entities.Snt> LoadSntOrDefaultByExternalIdAsync(this IDbContext context, long externalId, CancellationToken cancellationToken)
        {
            return await context.Snts
                .AddAllSntIncludes()
                .SingleOrDefaultAsync(x => x.ExternalId == externalId, cancellationToken);
        }

        public static async Task<IQueryable<TSource>> ApplyPagingAsync<TSource>(this IQueryable<TSource> query, PagingModel paging, CancellationToken cancellationToken)
        {
            paging.TotalRecords = await query.CountAsync(cancellationToken);

            if (paging.TotalRecords == 0)
            {
                paging.CurrentPage = 1;
                paging.PageCount = 0;
                return query;
            }

            paging.PageCount = Convert.ToInt32(Math.Ceiling(paging.TotalRecords / (double)paging.ItemsPerPage));

            if (paging.PageCount < paging.CurrentPage)
            {
                paging.CurrentPage = paging.PageCount;
            }

            var skip = (paging.CurrentPage - 1) * paging.ItemsPerPage;

            query = query.Skip(skip).Take(paging.ItemsPerPage);

            return query;
        }
    }
}
