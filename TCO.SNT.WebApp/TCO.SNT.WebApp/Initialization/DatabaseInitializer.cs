using Extensions.Hosting.AsyncInitialization;
using System.Threading;
using System.Threading.Tasks;
using TCO.EInvoicing.DataAccess.Interfaces;
using TCO.Finportal.Shared.DataAccess.Interfaces;
using TCO.SNT.DataAccess.Interfaces;

namespace TCO.SNT.WebApp.Initialization
{
    public class DatabaseInitializer : IAsyncInitializer
    {
        private readonly ISharedDbContext _sharedDbContext;
        private readonly IDbContext _context;
        private readonly IEInvoicingDbContext _einvoicingDbContext;

        public DatabaseInitializer(ISharedDbContext sharedDbContext,
            IDbContext context, 
            IEInvoicingDbContext einvoicingDbContext)
        {
            _context = context;
            _einvoicingDbContext = einvoicingDbContext;
            _sharedDbContext = sharedDbContext;
        }

        public async Task InitializeAsync()
        {
            // Order of modules is important. And shared must be first because EI and SNT modules use it.
            await _sharedDbContext.MigrateAsync(CancellationToken.None);
            await _context.MigrateAsync(CancellationToken.None);
            await _einvoicingDbContext.MigrateAsync(CancellationToken.None);
        }
    }
}
