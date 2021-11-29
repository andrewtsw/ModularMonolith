using AutoMapper;
using TCO.SNT.UseCases.Snt.Queries.SearchSntParticipantsByName;
using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.UseCases.Snt.Mapping
{
    internal class SntDtoMappingProfile : Profile
    {
        public SntDtoMappingProfile()
        {
            CreateMap<Entities.Snt, SntSimpleDto>()
                .ForMember(dest => dest.RegistrationNumber, opt => opt.MapFrom(src => src.SntInfo.RegistrationNumber))
                .ForMember(dest => dest.LastUpdateDate,
                    opt => opt.MapFrom(src => src.SntInfo.LastUpdateDateUtc.UtcDateTime))
                .ForMember(dest => dest.InputDate, opt => opt.MapFrom(src => src.SntInfo.InputDateUtc.UtcDateTime))
                .ForMember(dest => dest.CancelReason, opt => opt.MapFrom(src => src.SntInfo.CancelReason))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.SntInfo.Status))
                .ForMember(dest => dest.SenderTin, opt => opt.MapFrom(src => src.Consignor.Tin))
                .ForMember(dest => dest.SenderNonResident, opt => opt.MapFrom(src => src.Consignor.NonResident))
                .ForMember(dest => dest.RecipientTin, opt => opt.MapFrom(src => src.Consignee.Tin))
                .ForMember(dest => dest.RecipientNonResident, opt => opt.MapFrom(src => src.Consignee.NonResident))
                .ForMember(dest => dest.CustomerTaxpareStoreId, opt =>
                {
                    opt.PreCondition(src => src.Customer != null);
                    opt.MapFrom(src => src.Customer.TaxpayerStoreId);
                })
                .ForMember(dest => dest.SellerTaxpareStoreId, opt =>
                {
                    opt.PreCondition(src => src.Seller != null);
                    opt.MapFrom(src => src.Seller.TaxpayerStoreId);
                });

            CreateMap<Entities.SntCustomer, SntParticipantShortDto>();
            CreateMap<Entities.SntSeller, SntParticipantShortDto>();
        }
    }
}
