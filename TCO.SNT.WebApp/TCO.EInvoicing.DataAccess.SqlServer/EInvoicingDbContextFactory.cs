using Microsoft.EntityFrameworkCore;
using TCO.EInvoicing.DataAccess.Interfaces;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.EInvoicing.DataAccess.SqlServer
{
    internal class EInvoicingDbContextFactory : IEInvoicingDbContextFactory
    {
        private readonly string _connectionStrng;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;

        public EInvoicingDbContextFactory(string connectionStrng, 
            ICurrentUserService currentUserService, IDateTime dateTime)
        {
            _connectionStrng = connectionStrng;
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public IEInvoicingDbContext Create()
        {
            var options = new DbContextOptionsBuilder<EInvoicingSqlServerDbContext>()
                .UseSqlServer(_connectionStrng)
                .Options;

            return new EInvoicingSqlServerDbContext(options, _currentUserService, _dateTime);
        }
    }
}
