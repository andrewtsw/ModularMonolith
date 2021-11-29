using MediatR;
using System.Collections.Generic;
using TCO.SNT.UseCases.Currency.Shared.Dto;

namespace TCO.SNT.UseCases.Currency.GetCurrency
{
    public class GetCurrencyQuery: IRequest<List<CurrencyDto>>
    {

    }
}
