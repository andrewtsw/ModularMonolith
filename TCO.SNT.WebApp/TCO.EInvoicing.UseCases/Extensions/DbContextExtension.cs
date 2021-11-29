using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.DataAccess.Interfaces;
using TCO.EInvoicing.Entities;
using TCO.Finportal.Framework.UseCases.Extensions;

namespace TCO.EInvoicing.UseCases.Extensions
{
    public static class DbContextExtension
    {
        public static IQueryable<Invoice> AddAllInvoiceIncludes(this IQueryable<Invoice> query)
        {
            return query
                .Include(i => i.InvoiceInfo)
                .Include(i => i.Sellers)
                .Include(i => i.Customers)
                .Include(i => i.Consignee)
                .Include(i => i.Consignor)
                .Include(i => i.DeliveryTerm)
                .Include(i => i.Products)
                .Include(i => i.ProductSet);
        }

        public static async Task<Invoice> LoadInvoiceByIdAsync(this IEInvoicingDbContext context, int id, CancellationToken cancellationToken)
        {
            return await context.Invoices
                .AddAllInvoiceIncludes()
                .SingleOrExceptionAsync(x => x.Id == id, cancellationToken);
        }
    }
}
