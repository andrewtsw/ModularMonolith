using AutoMapper;
using EsfApiSdk.Awp;
using System;
using System.Globalization;
using TCO.EInvoicing.EsfApi.Interfaces.Awp.Models;
using TCO.EInvoicing.UseCases.Awp.Models;
using TCO.SNT.Common.Serialization;
using TCO.SNT.EsfApi.Interfaces.Awp;

namespace TCO.EInvoicing.UseCases.Awp.Mapping
{
    internal class AwpMappingProfile : Profile
    {
        public AwpMappingProfile()
        {
            CreateMap<AwpInfo, Entities.Awp>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Number, opt => opt.Ignore())
                .ForMember(dest => dest.AwpDate, opt => opt.Ignore())
                .ForMember(dest => dest.AwpSignDate, opt => opt.Ignore())
                .ForMember(dest => dest.SenderTin, opt => opt.Ignore())
                .ForMember(dest => dest.RecipientTin, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.awpId))
                .ForMember(dest => dest.RegistrationNumber, opt => opt.MapFrom(src => src.registrationNumber));                            

            CreateMap<Entities.Awp, AwpDto>();
        }        
    }
}
