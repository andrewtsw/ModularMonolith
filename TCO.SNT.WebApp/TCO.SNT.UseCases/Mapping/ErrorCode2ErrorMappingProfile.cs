using AutoMapper;
using TCO.Finportal.Framework.Domain.Entities;

namespace TCO.SNT.UseCases.Mapping
{
    public class ErrorCode2ErrorMappingProfile: Profile
    {
        public ErrorCode2ErrorMappingProfile()
        {
            CreateMap<Entities.ErrorCode, Error>()
                .ForMember(dest => dest.ErrorCode, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Description))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
