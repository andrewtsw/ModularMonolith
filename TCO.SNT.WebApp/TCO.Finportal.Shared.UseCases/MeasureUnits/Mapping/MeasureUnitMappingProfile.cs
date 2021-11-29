using AutoMapper;
using TCO.Finportal.Shared.UseCases.MeasureUnits.Queries.Shared.Dto;
using VsSdk.Dictionaries;
using DomainEntities = TCO.Finportal.Framework.Domain.Entities;


namespace TCO.Finportal.Shared.UseCases.MeasureUnits.Mapping
{
    internal class MeasureUnitMappingProfile : Profile
    {
        public MeasureUnitMappingProfile()
        {
            CreateMap<MeasureUnit, DomainEntities.MeasureUnit>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.LastUpdateDateUtc,
                    opt => opt.MapFrom(src => src.lastUpdateDate.ToUniversalTime()));            

            CreateMap<DomainEntities.MeasureUnit, MeasureUnitDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NameRu));
        }
    }
}
