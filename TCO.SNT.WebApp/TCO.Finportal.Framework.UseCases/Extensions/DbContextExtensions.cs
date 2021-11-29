using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TCO.Finportal.Framework.UseCases.Extensions
{
    public static class DbContextExtensions
    {
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
