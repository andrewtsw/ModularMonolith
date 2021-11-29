using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TCO.SNT.ExchangeRates.Interfaces
{
    public interface IExchangeRatesService
    {
        Task<IReadOnlyList<CurrencyRate>> GetRatesAsync(DateTime date, CancellationToken cancellationToken);
    }
}
