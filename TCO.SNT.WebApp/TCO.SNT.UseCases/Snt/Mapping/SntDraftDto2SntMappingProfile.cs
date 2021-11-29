using AutoMapper;
using TCO.SNT.UseCases.Snt.Commands.SaveDraft;
using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.UseCases.Snt.Mapping
{
    internal class SntDraftDtoMappingProfile : Profile
    {
        public SntDraftDtoMappingProfile()
        {
            CreateMap<SntDraftDto, Entities.Snt>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalId, opt => opt.Ignore())
                .ForMember(dest => dest.SntInfo, opt => opt.Ignore())
                .ForMember(dest => dest.AcceptanceGoodsInfo, opt => opt.Ignore())
                .ForMember(dest => dest.DocumentInfo, opt => opt.Ignore())
                .ForMember(dest => dest.OgdMarksInfo, opt => opt.Ignore())
                // These fields are editable only for SNT creation/correction
                .ForMember(dest => dest.SntType, opt => opt.Ignore())
                .ForMember(dest => dest.Date, opt => opt.Ignore())
                // Ignore ProductSet because it contains only calculated properties.
                .ForMember(dest => dest.ProductSet, opt => opt.Ignore())
                // Products and OilProducts will be mapped manually
                .ForMember(dest => dest.Products, opt => opt.Ignore())
                .ForMember(dest => dest.OilProducts, opt => opt.Ignore())
                // MptId dies not used for now
                .ForMember(dest => dest.MptId, opt => opt.Ignore());

            CreateMap<SntConsignmentParticipantDto, Entities.SntConsignee>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore())
                // Ignore additional info because it does not used on UI
                .ForMember(dest => dest.AdditionalInfo, opt => opt.Ignore());

            CreateMap<SntConsignmentParticipantDto, Entities.SntConsignor>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore())
                // Ignore additional info because it does not used on UI
                .ForMember(dest => dest.AdditionalInfo, opt => opt.Ignore());

            CreateMap<SntContractDto, Entities.SntContract>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore());

            CreateMap<SntCustomerDto, Entities.SntCustomer>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalStoreId, opt => opt.Ignore())
                .ForMember(dest => dest.TaxpayerStore, opt => opt.Ignore());

            CreateMap<SntSellerDto, Entities.SntSeller>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalStoreId, opt => opt.Ignore())
                .ForMember(dest => dest.TaxpayerStore, opt => opt.Ignore());

            CreateMap<SntShippingInfoDto, Entities.SntShippingInfo>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore());

            CreateMap<SntCarCargoInfoDto, Entities.SntCarCargoInfo>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore());

            CreateMap<SntOilSetDto, Entities.SntOilSet>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore())
                // Ignore calculated properties
                .ForMember(dest => dest.TotalExciseAmount, opt => opt.Ignore())
                .ForMember(dest => dest.TotalNdsAmount, opt => opt.Ignore())
                .ForMember(dest => dest.TotalPriceWithoutTax, opt => opt.Ignore())
                .ForMember(dest => dest.TotalPriceWithTax, opt => opt.Ignore());

            CreateMap<SntProductDtoBase, Entities.SntProductBase>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore())
                .ForMember(dest => dest.MeasureUnit, opt => opt.Ignore())
                .ForMember(dest => dest.Balance, opt => opt.Ignore())
                .ForMember(dest => dest.Gsvs, opt => opt.Ignore())
                // Convert enum to string
                .ForMember(dest => dest.TruOriginCode, opt => opt.MapFrom(src => src.TruOriginCode))
                // ProductNumber calculated from products order
                .ForMember(dest => dest.ProductNumber, opt => opt.Ignore())
                // Tnved/Gtin/ProductId copied from Balance
                .ForMember(dest => dest.TnvedCode, opt => opt.Ignore())
                .ForMember(dest => dest.ProductId, opt => opt.Ignore())
                // These fields are calculated
                .ForMember(dest => dest.PriceWithoutTax, opt => opt.Ignore())
                .ForMember(dest => dest.ExciseAmount, opt => opt.Ignore())
                .ForMember(dest => dest.NdsAmount, opt => opt.Ignore())
                .ForMember(dest => dest.PriceWithTax, opt => opt.Ignore())
                // Not used for now
                .ForMember(dest => dest.DeclarationNumberForSnt, opt => opt.Ignore())
                .ForMember(dest => dest.ProductNumberInDeclaration, opt => opt.Ignore());

            CreateMap<SntDraftProductDto, Entities.SntProduct>()
                .IncludeBase<SntProductDtoBase, Entities.SntProductBase>()
                // ExternalMeasureUnitCode Copied from the MeasureUnit
                .ForMember(dest => dest.ExternalMeasureUnitCode, opt => opt.Ignore());

            CreateMap<SntDraftOilProductDto, Entities.SntOilProduct>()
               .IncludeBase<SntProductDtoBase, Entities.SntProductBase>()
               // ExternalMeasureUnitCode Copied from the MeasureUnit
               .ForMember(dest => dest.ExternalMeasureUnitCode, opt => opt.Ignore())
               // PinCode will be copied from the Balance
               .ForMember(dest => dest.PinCode, opt => opt.Ignore());
        }
    }
}
