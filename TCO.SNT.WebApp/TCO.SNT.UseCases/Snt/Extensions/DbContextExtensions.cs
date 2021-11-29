using System;
using System.Linq;
using TCO.Finportal.Framework.Domain.Exceptions;
using TCO.Finportal.Framework.UseCases;
using TCO.SNT.Common.Extensions;
using TCO.SNT.Common.Options;
using TCO.SNT.Entities;
using TCO.SNT.Infrastructure.Interfaces;
using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.UseCases.Snt.Extensions
{
    public static class DbContextExtensions
    {
        public static IQueryable<Entities.Snt> ApplyFilter(this IQueryable<Entities.Snt> query, SntListFilter filter, CompanyOptions companyOptions)
        {
            if (filter == null)
                return query;

            // TODO:
            // 1. Add DB indexes
            // 2. Add Autofilter
            // 3. Show only awailable snt (by available stores)
            // 4. Clarify filter logic for string fields: equals, startwith, contains
            // 5. Add sorting
            // 6. Add paging
            // 7. Check access to sender and recepient store id in filter
            // 8. Add MaxLen for UForm and all related entities
            // 9. Add maxlen to string filter fields

            if (filter.DateFrom.HasValue)
            {
                query = query.Where(x => x.Date >= filter.DateFrom.Value);
            }
            if (filter.DateTo.HasValue)
            {
                query = query.Where(x => x.Date < filter.DateTo.Value.AddDays(1));
            }
            if (filter.Type.HasValue)
            {
                query = ApplyTypeFilter(query, filter);
            }
            if (filter.Status.HasValue)
            {
                query = query.Where(x => x.SntInfo.Status == filter.Status);
            }
            if (filter.Category.HasValue)
            {
                query = ApplyCategoryFilter(query, filter, companyOptions);
            }
            if (filter.LastUpdateDateFromUtc.HasValue)
            {
                query = query.Where(x => x.SntInfo.LastUpdateDateUtc >= filter.LastUpdateDateFromUtc.Value);
            }
            if (filter.LastUpdateDateToUtc.HasValue)
            {
                query = query.Where(x => x.SntInfo.LastUpdateDateUtc < filter.LastUpdateDateFromUtc.Value.AddDays(1));
            }
            if (!string.IsNullOrEmpty(filter.SellerTin))
            {
                query = query.Where(x => x.Seller.Tin.Contains(filter.SellerTin));
            }
            if (!string.IsNullOrEmpty(filter.CustomerTin))
            {
                query = query.Where(x => x.Customer.Tin.Contains(filter.CustomerTin));
            }
            if (!string.IsNullOrEmpty(filter.Number))
            {
                query = query.Where(x => x.Number.Contains(filter.Number));
            }
            if (!string.IsNullOrEmpty(filter.RegistrationNumber))
            {
                query = query.Where(x => x.SntInfo.RegistrationNumber.Contains(filter.RegistrationNumber));
            }
            if (filter.SellerStoreId.HasValue)
            {
                query = query.Where(x => x.Seller.TaxpayerStoreId == filter.SellerStoreId.Value);
            }
            if (filter.CustomerStoreId.HasValue)
            {
                query = query.Where(x => x.Customer.TaxpayerStoreId == filter.CustomerStoreId.Value);
            }

            return query;
        }

        private static IQueryable<Entities.Snt> ApplyTypeFilter(IQueryable<Entities.Snt> query, SntListFilter filter)
        {
            switch (filter.Type.Value)
            {
                case SntFilterType.PRIMARY_SNT:
                    query = query.Where(x => x.SntType == SntType.PRIMARY_SNT);
                    if (filter.ImportType.HasValue)
                        query = query.Where(x => x.ImportType == filter.ImportType.Value);
                    else
                        query = query.Where(x => x.ImportType != null);
                    break;
                case SntFilterType.RETURNED_SNT:
                    query = query.Where(x => x.SntType == SntType.RETURNED_SNT);
                    break;
                case SntFilterType.FIXED_SNT:
                    query = query.Where(x => x.SntType == SntType.FIXED_SNT);
                    break;
                case SntFilterType.EXPORT_SNT:
                    if (filter.ExportType.HasValue)
                        query = query.Where(x => x.ExportType == filter.ExportType.Value);
                    else
                        query = query.Where(x => x.ExportType != null);
                    break;
                case SntFilterType.TRANSFER_SNT:
                    if (filter.TransferType.HasValue)
                        query = query.Where(x => x.TransferType == filter.TransferType.Value);
                    else
                        query = query.Where(x => x.TransferType != null);
                    break;
                case SntFilterType.IS_PAPER_SNT:
                    query = query.Where(x => x.DatePaper != null);
                    break;
                default: throw new NotSupportedException($"Unknown value for filter.Type = {filter.Type.Value}");
            }

            return query;
        }

        private static IQueryable<Entities.Snt> ApplyCategoryFilter(IQueryable<Entities.Snt> query, SntListFilter filter, CompanyOptions companyOptions)
        {
            return filter.Category.Value switch
            {
                SntCategory.INBOUND => query.Where(x => x.Seller.Tin == companyOptions.Tin),
                SntCategory.OUTBOUND => query.Where(x => x.Customer.Tin == companyOptions.Tin),
                SntCategory.INPROGRESS => filter.Status == null
                    ? query.Where(x => x.SntInfo.Status.In(new[] { SntStatus.DRAFT, SntStatus.FAILED, SntStatus.IMPORTED }))
                    : query,
                _ => throw new NotSupportedException($"Unknown value for filter.Category = {filter.Category.Value}")
            };
        }

        public static IQueryable<Entities.Snt> ApplySorting(this IQueryable<Entities.Snt> query, SortingModel sorting)
        {
            if (sorting == null)
            {
                return query.OrderByDescending(x => x.SntInfo.LastUpdateDateUtc);
            }

            if (sorting.SortOrder == SortingOrder.Desc)
            {
                return sorting.SortColumn switch
                {
                    "Number" => query.OrderByDescending(q => q.Number),
                    "RegistrationNumber" => query.OrderByDescending(q => q.SntInfo.RegistrationNumber),
                    "Date" => query.OrderByDescending(q => q.Date),
                    "SntType" => query.OrderByDescending(q => q.SntType),
                    "Status" => query.OrderByDescending(q => q.SntInfo.Status),
                    _ => throw new ValidationException($"Snt list does not support sorting by the {sorting.SortColumn} column."),
                };
            }

            return sorting.SortColumn switch
            {
                "Number" => query.OrderBy(q => q.Number),
                "RegistrationNumber" => query.OrderBy(q => q.SntInfo.RegistrationNumber),
                "Date" => query.OrderBy(q => q.Date),
                "SntType" => query.OrderBy(q => q.SntType),
                "Status" => query.OrderBy(q => q.SntInfo.Status),
                _ => throw new ValidationException($"Snt list does not support sorting by the {sorting.SortColumn} column."),
            };
        }
    }
}