using AutoMapper;
using TCO.SNT.UseCases.Country.Shared;

namespace TCO.SNT.UseCases.Country.Mapping
{
    public class Country2CountryDtoMappingProfile: Profile
    {
        public Country2CountryDtoMappingProfile()
        {
            CreateMap<Entities.Country, CountryDto>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Alpha2))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NameRu));
        }
    }
}
