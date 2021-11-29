using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.Entities;
using TCO.EInvoicing.Entities.Jde;

namespace TCO.EInvoicing.DataAccess.Interfaces
{
    public interface IEInvoicingDbContext : IDisposable
    {
        DbSet<Invoice> Invoices { get; }

        DbSet<InvoiceConsignee> InvoiceConsignees { get; }

        DbSet<InvoiceConsignor> InvoiceConsignors { get; }

        DbSet<InvoiceCustomer> InvoiceCustomers { get; }

        DbSet<InvoiceDeliveryTerm> InvoiceDeliveryTerms { get; }

        DbSet<InvoiceSeller> InvoiceSellers { get; }

        DbSet<RelatedInvoice> RelatedInvoices { get; }

        DbSet<InvoicePublicOffice> InvoicePublicOffices { get; }

        DbSet<InvoiceProductSet> InvoiceProductSets { get; }

        DbSet<InvoiceProduct> InvoiceProducts { get; }

        DbSet<Awp> Awps{ get; }

        DbSet<JdeArInvoice> JdeArInvoices { get; }

        Task<EInvoicingSettings> LoadSettingsAsync(CancellationToken cancellationToken);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        Task MigrateAsync(CancellationToken cancellationToken);

        Task BulkInsertEntitiesAsync<T>(IList<T> entities, CancellationToken cancellationToken)
            where T : class;

        Task BulkInsertInvoicesAsync(IList<Invoice> invoices, CancellationToken cancellationToken);

        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
    }
}