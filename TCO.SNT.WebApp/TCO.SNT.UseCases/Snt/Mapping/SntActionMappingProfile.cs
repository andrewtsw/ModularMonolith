using AutoMapper;
using TCO.SNT.UseCases.Snt.Commands.ChangeSntStatus;
using TCO.SNT.EsfApi.Interfaces.Snt;

namespace TCO.SNT.UseCases.Snt.Mapping
{
    internal class SntActionMappingProfile : Profile
    {
        public SntActionMappingProfile()
        {
            CreateMap<ChangeSntStatusCommand, SntAction>()
                .ForMember(dest => dest.actionType, opt => opt.MapFrom(src => src.ActionType))
                .ForMember(dest => dest.cause, opt => opt.MapFrom(src => src.ChangeSntStatusDto.Cause))
                .ForMember(dest => dest.powerOfAttorneyDate, opt => opt.MapFrom(src => src.ChangeSntStatusDto.PowerOfAttorneyDate))
                .ForMember(dest => dest.powerOfAttorneyNumber, opt => opt.MapFrom(src => src.ChangeSntStatusDto.PowerOfAttorneyNumber))
                .ForMember(dest => dest.sntId, opt => opt.Ignore())
                .ForMember(dest => dest.originalDocumentSignature, opt => opt.Ignore());
        }
    }
}

