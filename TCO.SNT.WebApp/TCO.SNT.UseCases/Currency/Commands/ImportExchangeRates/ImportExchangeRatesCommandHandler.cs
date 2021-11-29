using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TCO.SNT.DataAccess.Interfaces;
using TCO.SNT.ExchangeRates.Interfaces;
using TCO.SNT.Infrastructure.Interfaces;

namespace TCO.SNT.UseCases.Currency.Commands.ImportExchangeRates
{
    internal class ImportExchangeRatesCommandHandler : IRequestHandler<ImportExchangeRatesCommand, ImportExchangeRatesResultDto>
    {
        private readonly IDbContext _context;
        private readonly IDateTime _dateTime;
        private readonly IExchangeRatesService _exchangeRatesService;

        public ImportExchangeRatesCommandHandler(IDbContext context, IDateTime dateTime,
            IExchangeRatesService exchangeRatesService)
        {
            _context = context;
            _dateTime = dateTime;
            _exchangeRatesService = exchangeRatesService;
        }

        public async Task<ImportExchangeRatesResultDto> Handle(ImportExchangeRatesCommand request, CancellationToken cancellationToken)
        {
            var rates = await _exchangeRatesService.GetRatesAsync(_dateTime.UtcNow, cancellationToken);
            var currenciesByCode = await _context.Currencies.ToDictionaryAsync(x => x.Code, cancellationToken);
            
            var result = Merge(rates, currenciesByCode);

            await _context.SaveChangesAsync(cancellationToken);

            return result;
        }

        private ImportExchangeRatesResultDto Merge(IEnumerable<CurrencyRate> rates, IDictionary<string, Entities.Currency> currenciesByCode)
        {
            var result = new ImportExchangeRatesResultDto();
            foreach (var rate in rates)
            {
                var code = rate.Title.ToUpper();
                if (!currenciesByCode.TryGetValue(rate.Title.ToUpper(), out var currency))
                {
                    currency = new Entities.Currency { Code = code };
                    _context.Currencies.Add(currency);
                    result.Added++;
                }
                else
                {
                    result.Updated++;
                }
                currency.Rate = rate.CalculateRate();
            }

            return result;
        }
    }
}
