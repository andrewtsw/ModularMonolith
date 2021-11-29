using MediatR;
using System.Collections.Generic;
using TCO.SNT.UseCases.Currency.Shared.Dto;

namespace TCO.SNT.UseCases.Currency.GetFavouriteCurrency
{
    public class GetFavouriteCurrencyQuery: IRequest<IReadOnlyList<CurrencyDto>>
    {
    }
}
