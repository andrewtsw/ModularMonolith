using System.Linq;
using TCO.SNT.UseCases.Balances.Shared;
using TCO.SNT.UseCases.Shared;
using TCO.Finportal.Framework.Domain.Exceptions;
using TCO.Finportal.Framework.UseCases;

namespace TCO.SNT.UseCases.Balances.Extentions
{
    internal static class BalanceQueryExtensions
    {
        public static IQueryable<Entities.Balance> ApplyFilter(this IQueryable<Entities.Balance> query, BalanceFilter filter)
        {
            if (filter == null)
            {
                return query;
            }

            if (!string.IsNullOrEmpty(filter.Name))
            {
                query = query.Where(x => x.Name.Contains(filter.Name));
            }

            if (!string.IsNullOrEmpty(filter.ProductNameInImportDoc))
            {
                query = query.Where(x => x.ProductNameInImportDoc.Contains(filter.ProductNameInImportDoc));
            }

            if (!string.IsNullOrEmpty(filter.ProductNumberInImportDoc))
            {
                query = query.Where(x => x.ProductNumberInImportDoc == filter.ProductNumberInImportDoc);
            }

            if (!string.IsNullOrEmpty(filter.ManufactureOrImportDocNumber))
            {
                query = query.Where(x => x.ManufactureOrImportDocNumber == filter.ManufactureOrImportDocNumber);
            }

            if (filter.ProductId.HasValue)
            {
                query = query.Where(x => x.ProductId == filter.ProductId.Value);
            }

            if (filter.UnitPrice.HasValue)
            {
                query = query.Where(x => x.UnitPrice == filter.UnitPrice.Value);
            }

            if (!string.IsNullOrEmpty(filter.KpvedCode))
            {
                query = query.Where(x => x.KpvedCode == filter.KpvedCode);
            }

            if (!string.IsNullOrEmpty(filter.TnvedCode))
            {
                query = query.Where(x => x.TnvedCode == filter.TnvedCode);
            }

            if (!string.IsNullOrEmpty(filter.GtinCode))
            {
                query = query.Where(x => x.GtinCode == filter.GtinCode);
            }

            if (!string.IsNullOrEmpty(filter.PhysicalLabel))
            {
                query = query.Where(x => x.PhysicalLabel == filter.PhysicalLabel);
            }

            if (filter.TaxpayerStoreId.HasValue)
            {
                query = query.Where(x => x.TaxpayerStoreId == filter.TaxpayerStoreId.Value);
            }

            if (filter.MeasureUnitId.HasValue)
            {
                query = query.Where(x => x.MeasureUnitId == filter.MeasureUnitId.Value);
            }

            return query;
        }

        public static IQueryable<Entities.Balance> ApplySorting(this IQueryable<Entities.Balance> query, SortingModel sorting)
        {
            if (sorting == null)
            {
                // There is no LastUpdated column in the Balance entity. So we sort by Id by default
                return query.OrderByDescending(x => x.Id);
            }

            if (sorting.SortOrder == SortingOrder.Desc)
            {
                return sorting.SortColumn switch
                {
                    "ProductId" => query.OrderByDescending(q => q.ProductId),
                    "Name" => query.OrderByDescending(q => q.Name),
                    "KpvedCode" => query.OrderByDescending(q => q.KpvedCode),
                    "TnvedCode" => query.OrderByDescending(q => q.TnvedCode),
                    "GtinCode" => query.OrderByDescending(q => q.GtinCode),
                    "UnitPrice" => query.OrderByDescending(q => q.UnitPrice),
                    "Quantity" => query.OrderByDescending(q => q.Quantity),
                    "ReserveQuantity" => query.OrderByDescending(q => q.ReserveQuantity),
                    _ => throw new ValidationException($"Balances list does not support sorting by the {sorting.SortColumn} column."),
                };
            }

            return sorting.SortColumn switch
            {
                "ProductId" => query.OrderBy(q => q.ProductId),
                "Name" => query.OrderBy(q => q.Name),
                "KpvedCode" => query.OrderBy(q => q.KpvedCode),
                "TnvedCode" => query.OrderBy(q => q.TnvedCode),
                "GtinCode" => query.OrderBy(q => q.GtinCode),
                "UnitPrice" => query.OrderBy(q => q.UnitPrice),
                "Quantity" => query.OrderBy(q => q.Quantity),
                "ReserveQuantity" => query.OrderBy(q => q.ReserveQuantity),
                _ => throw new ValidationException($"Balances list does not support sorting by the {sorting.SortColumn} column."),
            };
        }
    }
}
