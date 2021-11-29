using MediatR;
using System.Collections.Generic;
using TCO.SNT.UseCases.Country.Shared;

namespace TCO.SNT.UseCases.Country.GetFavouriteCountry
{
    public class GetFavouriteCountryQuery: IRequest<IReadOnlyList<CountryDto>>
    {
    }
}
