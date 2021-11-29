using AutoMapper;
using EsfApiSdk.Snt;
using System;
using System.Globalization;

namespace TCO.SNT.UseCases.Snt.Mapping
{
    internal class SntInfoMappingProfile : Profile
    {
        public SntInfoMappingProfile()
        {
            CreateMap<SntInfo, Entities.SntInfo>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore())
                .ForMember(dest => dest.InputDateUtc, opt => opt.MapFrom(src => src.inputDate.ToUniversalTime()))
                .ForMember(dest => dest.LastUpdateDateUtc, opt => opt.MapFrom(src => src.lastUpdateDate.ToUniversalTime()));

            CreateMap<SntSummary, Entities.SntInfo>()
                .ForMember(dest => dest.InputDateUtc, opt => opt.MapFrom(src => src.inputDate.ToUniversalTime()))
                .ForMember(dest => dest.LastUpdateDateUtc, opt => opt.MapFrom(src => src.lastUpdateDate.ToUniversalTime()))
                .ForMember(dest => dest.RegistrationNumber, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore())
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Version, opt => opt.Ignore());

            CreateMap<SntDocumentInfo, Entities.SntDocumentInfo>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatorProjectCode,
                    opt => opt.MapFrom(src => src.creatorProjectCodeSpecified ? src.creatorProjectCode : (long?)null));

            CreateMap<SntAcceptanceGoodsInfo, Entities.SntAcceptanceGoodsInfo>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore())
                .ForMember(dest => dest.AcceptanceOrRejectionDate,
                    opt => opt.MapFrom(src => DateTime.ParseExact(src.acceptanceOrRejectionDate, "dd.MM.yyyy", CultureInfo.InvariantCulture)));

            CreateMap<SntOgdMarksInfo, Entities.SntOgdMarksInfo>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore())
                .ForMember(dest => dest.SignDateUtc, opt => opt.MapFrom(src => src.signDate.ToUniversalTime()));

        }
    }
}
