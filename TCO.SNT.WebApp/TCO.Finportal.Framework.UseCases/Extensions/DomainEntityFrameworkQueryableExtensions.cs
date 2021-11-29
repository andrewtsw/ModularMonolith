using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Framework.Domain.Exceptions;

namespace TCO.Finportal.Framework.UseCases.Extensions
{
    public static class DomainEntityFrameworkQueryableExtensions
    {
        public static async Task<TSource> SingleOrExceptionAsync<TSource>([NotNull] this IQueryable<TSource> source, [NotNull] Expression<Func<TSource, bool>> predicate, CancellationToken cancellationToken)
        {
            var result = await source.SingleOrDefaultAsync(predicate, cancellationToken);
            if (result == null)
            {
                throw new EntityNotFoundException(typeof(TSource).Name);
            }

            return result;
        }


        public static async ValueTask<TSource> FindOrExceptionAsync<TSource>(this DbSet<TSource> source, object key, CancellationToken cancellationToken) where TSource : class
        {
            var results = await source.FindAsync(new[] { key }, cancellationToken);
            if (results == null)
            {
                throw new EntityNotFoundException(typeof(TSource).Name);
            }

            return results;
        }
    }
}