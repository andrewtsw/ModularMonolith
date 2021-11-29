using MediatR;
using System.Collections.Generic;
using TCO.SNT.UseCases.Country.Shared;

namespace TCO.SNT.UseCases.Country.GetCountry
{
    public class GetCountryQuery: IRequest<IReadOnlyList<CountryDto>>
    {
    }
}
