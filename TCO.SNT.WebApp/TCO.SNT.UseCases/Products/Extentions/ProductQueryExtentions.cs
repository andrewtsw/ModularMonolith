using System.Linq;

namespace TCO.SNT.UseCases.Products.Queries.SearchProducts
{
    public static class ProductQueryExtentions
    {
        public static IQueryable<Entities.Product> ApplyFilter(this IQueryable<Entities.Product> query, ProductFilter filter)
        {
            if (filter.IsEmpty())
            {
                // Return all root elements 
                query = query.Where(x => x.FixedParentId == Entities.Product.RootParentId);
                return query;
            }

            if (!string.IsNullOrEmpty(filter.Code))
                query = query.Where(x => x.Code == filter.Code);

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(x => x.NameRu.Contains(filter.Name));

            if (filter.SociallySignificant.HasValue)
                query = query.Where(x => x.IsSociallySignificant == filter.SociallySignificant.Value);

            if (filter.TwofoldPurpose.HasValue)
                query = query.Where(x => x.IsTwofoldPurpose == filter.TwofoldPurpose.Value);

            if (filter.Unique.HasValue)
                query = query.Where(x => x.IsUnique == filter.Unique.Value);

            if (filter.UseInVstore.HasValue)
                query = query.Where(x => x.IsUseInVstore.HasValue && x.IsUseInVstore == filter.UseInVstore.Value);

            if (filter.Withdrawal.HasValue)
                query = query.Where(x => x.IsWithdrawal.HasValue && x.IsWithdrawal == filter.Withdrawal.Value);

            if (filter.Excisable.HasValue)
                query = query.Where(x => x.IsExcisable == filter.Excisable.Value);


            return query;
        }

        public static IQueryable<Entities.Product> ApplySorting(this IQueryable<Entities.Product> query)
        {
            return query.OrderBy(x => x.Code);
        }

        public static IQueryable<Entities.Product> ApplyPaging(this IQueryable<Entities.Product> query, int maxItems)
        {
            return query.Take(maxItems);
        }

    }
}
