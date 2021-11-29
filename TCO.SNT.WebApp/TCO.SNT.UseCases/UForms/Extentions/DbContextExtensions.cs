using System.Linq;
using TCO.Finportal.Framework.Domain.Exceptions;
using TCO.Finportal.Framework.UseCases;
using TCO.SNT.Entities;
using TCO.SNT.UseCases.Shared;
using TCO.SNT.UseCases.UForms.Shared;

namespace TCO.SNT.UseCases.UForms.Extentions
{
    public static class DbContextExtensions
    {
        public static IQueryable<UForm> ApplyFilter(this IQueryable<UForm> query, UFormFilter filter)
        {
            if (filter == null)
            {
                return query;
            }

            // TODO: Add Autofilter                                

            if (!string.IsNullOrEmpty(filter.Number))
            {
                query = query.Where(x => x.Number.Contains(filter.Number));
            }
            if (!string.IsNullOrEmpty(filter.RegistrationNumber))
            {
                query = query.Where(x => x.UFormInfo.RegistrationNumber.Contains(filter.RegistrationNumber));
            }
            if (filter.DateFrom.HasValue)
            {
                query = query.Where(x => x.Date >= filter.DateFrom.Value);
            }
            if (filter.DateTo.HasValue)
            {
                query = query.Where(x => x.Date < filter.DateTo.Value.AddDays(1));
            }
            if (!string.IsNullOrEmpty(filter.SenderTin))
            {
                query = query.Where(x => x.Sender.Tin.Contains(filter.SenderTin));
            }
            if (!string.IsNullOrEmpty(filter.RecipientTin))
            {
                query = query.Where(x => x.Recipient.Tin.Contains(filter.RecipientTin));
            }
            if (filter.TotalSumFrom.HasValue)
            {
                query = query.Where(x => x.TotalSum >= filter.TotalSumFrom.Value);
            }
            if (filter.TotalSumTo.HasValue)
            {
                query = query.Where(x => x.TotalSum <= filter.TotalSumTo.Value);
            }
            if (filter.Type.HasValue)
            {
                query = query.Where(x => x.Type == filter.Type.Value);
            }
            if (filter.Status.HasValue)
            {
                query = query.Where(x => x.UFormInfo.Status == filter.Status.Value);
            }
            if (filter.SenderStoreId.HasValue)
            {
                query = query.Where(x => x.Sender.TaxpayerStoreId == filter.SenderStoreId.Value);
            }
            if (filter.RecipientStoreId.HasValue)
            {
                query = query.Where(x => x.Recipient.TaxpayerStoreId == filter.RecipientStoreId.Value);
            }

            return query;
        }

        public static IQueryable<UForm> ApplySorting(this IQueryable<UForm> query, SortingModel sorting)
        {
            if (sorting == null)
            {
                return query.OrderByDescending(x => x.UFormInfo.LastUpdateDateUtc);
            }

            if (sorting.SortOrder == SortingOrder.Desc)
            {
                return sorting.SortColumn switch
                {
                    "Number" => query.OrderByDescending(q => q.Number),
                    "RegistrationNumber" => query.OrderByDescending(q => q.UFormInfo.RegistrationNumber),
                    "Date" => query.OrderByDescending(q => q.UFormInfo.LastUpdateDateUtc),
                    "FormType" => query.OrderByDescending(q => q.Type),
                    "SenderTin" => query.OrderByDescending(q => q.Sender.Tin),
                    "RecipientTin" => query.OrderByDescending(q => q.Recipient.Tin),
                    "TotalSum" => query.OrderByDescending(q => q.TotalSum),
                    "Status" => query.OrderByDescending(q => q.UFormInfo.Status),
                    _ => throw new ValidationException($"Forms list does not support sorting by the {sorting.SortColumn} column."),
                };
            }

            return sorting.SortColumn switch
            {
                "Number" => query.OrderBy(q => q.Number),
                "RegistrationNumber" => query.OrderBy(q => q.UFormInfo.RegistrationNumber),
                "Date" => query.OrderBy(q => q.UFormInfo.LastUpdateDateUtc),
                "FormType" => query.OrderBy(q => q.Type),
                "SenderTin" => query.OrderBy(q => q.Sender.Tin),
                "RecipientTin" => query.OrderBy(q => q.Recipient.Tin),
                "TotalSum" => query.OrderBy(q => q.TotalSum),
                "Status" => query.OrderBy(q => q.UFormInfo.Status),
                _ => throw new ValidationException($"Forms list does not support sorting by the {sorting.SortColumn} column."),
            };
        }
    }
}
