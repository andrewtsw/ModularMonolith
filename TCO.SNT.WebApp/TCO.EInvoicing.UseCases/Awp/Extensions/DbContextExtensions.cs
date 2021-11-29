using System;
using System.Linq;
using TCO.EInvoicing.UseCases.Awp.Shared;
using TCO.Finportal.Framework.UseCases;

namespace TCO.EInvoicing.UseCases.Awp.Extensions
{
    public static class DbContextExtensions
    {
        public static IQueryable<Entities.Awp> ApplyFilter(this IQueryable<Entities.Awp> query, AwpListFilter filter)
        {
            if (filter == null)
                return query;            

            if (filter.DateFrom.HasValue)
            {
                query = query.Where(x => x.AwpDate >= filter.DateFrom.Value);
            }
            if (filter.DateTo.HasValue)
            {
                query = query.Where(x => x.AwpDate < filter.DateTo.Value.AddDays(1));
            }
            if (!string.IsNullOrEmpty(filter.RegistrationNumber))
            {
                query = query.Where(x => x.RegistrationNumber.Contains(filter.RegistrationNumber));
            }

            return query;
        }

        public static IQueryable<Entities.Awp> ApplySorting(this IQueryable<Entities.Awp> query, SortingModel sorting)
        {
            if (sorting == null)
            {
                return query.OrderByDescending(x => x.AwpDate);
            }

            if (sorting.SortOrder == SortingOrder.Desc)
            {
                return sorting.SortColumn switch
                {
                    "Number" => query.OrderByDescending(q => q.Number),
                    "RegistrationNumber" => query.OrderByDescending(q => q.RegistrationNumber),
                    "AwpDate" => query.OrderByDescending(q => q.AwpDate),
                    "AwpSignDate" => query.OrderByDescending(q => q.AwpSignDate),
                    "SenderTin" => query.OrderByDescending(q => q.SenderTin),
                    "RecipientTin" => query.OrderByDescending(q => q.RecipientTin),
                    "Status" => query.OrderByDescending(q => q.Status),
                    _ => throw new Exception($"Awp list does not support sorting by the {sorting.SortColumn} column."),
                };
            }

            return sorting.SortColumn switch
            {
                "Number" => query.OrderBy(q => q.Number),
                "RegistrationNumber" => query.OrderBy(q => q.RegistrationNumber),
                "AwpDate" => query.OrderBy(q => q.AwpDate),
                "AwpSignDate" => query.OrderBy(q => q.AwpSignDate),
                "SenderTin" => query.OrderBy(q => q.SenderTin),
                "RecipientTin" => query.OrderBy(q => q.RecipientTin),
                "Status" => query.OrderBy(q => q.Status),
                _ => throw new Exception($"Awp list does not support sorting by the {sorting.SortColumn} column."),
            };
        }
    }
}
