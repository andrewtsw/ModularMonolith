using AutoMapper;
using TCO.SNT.UseCases.Snt.Commands.ChangeSntStatus;

namespace TCO.SNT.UseCases.Snt.Mapping
{
    internal class ChangeSntStatusDtoMappingProfile : Profile
    {
        public ChangeSntStatusDtoMappingProfile()
        {
            CreateMap<RevokeSntDto, ChangeSntStatusDto>()
                .ForMember(dest => dest.Cause, opt => opt.MapFrom(src => src.Cause))
                .ForMember(dest => dest.PowerOfAttorneyDate, opt => opt.Ignore())
                .ForMember(dest => dest.PowerOfAttorneyNumber, opt => opt.Ignore())
                .ForMember(dest => dest.SntId, opt => opt.MapFrom(src => src.SntId))
                .ForMember(dest => dest.OriginalDocumentSignature, opt => opt.Ignore());

            CreateMap<ConfirmSntDto, ChangeSntStatusDto>()
                .ForMember(dest => dest.Cause, opt => opt.Ignore())
                .ForMember(dest => dest.PowerOfAttorneyDate, opt => opt.MapFrom(src => src.PowerOfAttorneyDate.ToString("dd.MM.yyyy")))
                .ForMember(dest => dest.PowerOfAttorneyNumber, opt => opt.MapFrom(src => src.PowerOfAttorneyNumber))
                .ForMember(dest => dest.SntId, opt => opt.MapFrom(src => src.SntId))
                .ForMember(dest => dest.OriginalDocumentSignature, opt => opt.Ignore());

            CreateMap<DeclineSntDto, ChangeSntStatusDto>()
                .ForMember(dest => dest.Cause, opt => opt.MapFrom(src => src.Cause))
                .ForMember(dest => dest.PowerOfAttorneyDate, opt => opt.Ignore())
                .ForMember(dest => dest.PowerOfAttorneyNumber, opt => opt.Ignore())
                .ForMember(dest => dest.SntId, opt => opt.MapFrom(src => src.SntId))
                .ForMember(dest => dest.OriginalDocumentSignature, opt => opt.Ignore());
        }
    }

}

