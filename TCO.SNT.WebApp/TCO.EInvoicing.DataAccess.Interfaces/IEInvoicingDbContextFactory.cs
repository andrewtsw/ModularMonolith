namespace TCO.EInvoicing.DataAccess.Interfaces
{
    public interface IEInvoicingDbContextFactory
    {
        IEInvoicingDbContext Create();
    }
}
