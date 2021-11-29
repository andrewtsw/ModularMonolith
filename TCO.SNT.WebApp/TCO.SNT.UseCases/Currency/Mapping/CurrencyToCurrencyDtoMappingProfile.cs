using AutoMapper;
using TCO.SNT.UseCases.Currency.Shared.Dto;

namespace TCO.SNT.UseCases.Currency.Mapping
{
    public class CurrencyToCurrencyDtoMappingProfile: Profile
    {
        public CurrencyToCurrencyDtoMappingProfile()
        {
            CreateMap<Entities.Currency, CurrencyDto>();
        }
    }
}
