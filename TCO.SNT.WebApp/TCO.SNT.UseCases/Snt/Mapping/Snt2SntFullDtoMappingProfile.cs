using AutoMapper;
using TCO.SNT.UseCases.Snt.Queries.GetSntFull;
using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.UseCases.Snt.Mapping
{
    internal class Snt2SntFullDtoMappingProfile : Profile
    {
        public Snt2SntFullDtoMappingProfile()
        {
            CreateMap<Entities.Snt, SntFullDto>()
                .ForMember(dest => dest.RegistrationNumber, opt => opt.MapFrom(src => src.SntInfo.RegistrationNumber));

            CreateMap<Entities.SntConsignee, SntConsignmentParticipantDto>();
            CreateMap<Entities.SntConsignor, SntConsignmentParticipantDto>();
            CreateMap<Entities.SntContract, SntContractDto>();
            CreateMap<Entities.SntParticipant, SntParticipantDto>();
            CreateMap<Entities.SntCustomer, SntCustomerDto>();
            CreateMap<Entities.SntSeller, SntSellerDto>();
            CreateMap<Entities.SntShippingInfo, SntShippingInfoDto>();
            CreateMap<Entities.SntCarCargoInfo, SntCarCargoInfoDto>();

            CreateMap<Entities.SntProductBase, SntProductDtoBase>()
              .ForMember(dest => dest.ProductName, opt => opt.Ignore())
              .ForMember(dest => dest.Quantity, opt => opt.Ignore())
              .ForMember(dest => dest.Price, opt => opt.Ignore());

            CreateMap<Entities.SntProduct, SntProductFullDto>()
              .IncludeBase<Entities.SntProductBase, SntProductDtoBase>()
              .ForMember(dest => dest.MeasureUnitName, opt => opt.MapFrom(src => src.MeasureUnit.NameRu))
              // Map to base class
              .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
              .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
              .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
              // Map from base class
              .ForMember(dest => dest.TnvedCode, opt => opt.MapFrom(src => src.TnvedCode));

            CreateMap<Entities.SntOilProduct, SntOilProductDto>()
                .IncludeBase<Entities.SntProductBase, SntProductDtoBase>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.MeasureUnitName, opt => opt.MapFrom(src => src.MeasureUnit.NameRu))
                .ForMember(dest => dest.TnvedCode, opt => opt.MapFrom(src => src.TnvedCode))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            CreateMap<Entities.SntOilSet, SntOilSetDto>();


        }
    }
}
