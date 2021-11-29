using AutoMapper;
using System;
using TCO.SNT.Common.Extensions;
using TCO.SNT.Resources;

namespace TCO.SNT.Infrastructure.Implementation.ReportBuilders.Mapping
{
    internal class Snt2SntReportRowProfile : Profile
    {
        public Snt2SntReportRowProfile()
        {
            CreateMap<Entities.Snt, SntReportRow>()
                .ForMember(dest => dest.RegistrationNumber, opt => opt.MapFrom(src => src.SntInfo.RegistrationNumber))
                .ForMember(dest => dest.SntType, opt => opt.MapFrom(src => SntTypeResource.ResourceManager.GetString(src.SntType.ToString())))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => SntStatusResource.ResourceManager.GetString(src.SntInfo.Status.ToString())))
                .ForMember(dest => dest.SenderTin, opt => opt.MapFrom(src => src.Consignor.Tin))
                .ForMember(dest => dest.RecipientTin, opt => opt.MapFrom(src => src.Consignee.Tin))
                .ForMember(dest => dest.DeliveryCondition, opt => opt.MapFrom(src => src.Contract.DeliveryCondition))
                .ForMember(dest => dest.SenderCountryCode, opt => opt.MapFrom(src => src.Consignor.CountryCode))
                .ForMember(dest => dest.SenderActualAddress, opt => opt.MapFrom(src => src.Seller.ActualAddress))
                .ForMember(dest => dest.RecepientCountryCode, opt => opt.MapFrom(src => src.Consignee.CountryCode))
                .ForMember(dest => dest.RecepientActualAddress, opt => opt.MapFrom(src => src.Customer.ActualAddress))
                .ForMember(dest => dest.TcoApproveDate, opt =>
                {
                    opt.PreCondition(src => src.AcceptanceGoodsInfo != null && src.AcceptanceGoodsInfo.AcceptanceOrRejectionDate.ToUniversalTime() != DateTime.MinValue);
                    opt.MapFrom(src => src.AcceptanceGoodsInfo.AcceptanceOrRejectionDate.ToStringCommonDateFormat());
                })
                .ForMember(dest => dest.OgdApproveDate, opt =>
                {
                    opt.PreCondition(src => src.OgdMarksInfo != null && src.OgdMarksInfo.SignDateUtc.ToUniversalTime() != DateTime.MinValue);
                    opt.MapFrom(src => src.OgdMarksInfo.SignDateUtc.ToStringCommonDateFormat());
                })
                .ForMember(dest => dest.Date, opt =>
                {
                    opt.PreCondition(src => src.Date.HasValue);
                    opt.MapFrom(src => src.Date.Value.ToStringCommonDateFormat());
                })
                .ForMember(dest => dest.Deadline, opt =>
                {
                    opt.PreCondition(src => src.Date.HasValue);
                    opt.MapFrom(src => src.GetDeadline().Value.ToStringCommonDateFormat());
                })
                .ForMember(dest => dest.TaxpareStoreName, opt => opt.Ignore())
                .ForMember(dest => dest.TaxpareStoreId, opt => opt.Ignore())
                .ForMember(dest => dest.ProductName, opt => opt.Ignore())
                .ForMember(dest => dest.Price, opt => opt.Ignore())
                .ForMember(dest => dest.Quantity, opt => opt.Ignore())
                .ForMember(dest => dest.Total, opt => opt.Ignore());

            CreateMap<Entities.SntProduct, SntReportRow>()
                .ForMember(dest => dest.TaxpareStoreId, opt => opt.MapFrom(src => src.Balance.TaxpayerStoreId))
                .ForMember(dest => dest.TaxpareStoreName, opt => opt.MapFrom(src => src.Balance.TaxpayerStore.StoreName))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.CalculateTotal()))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<Entities.SntOilProduct, SntReportRow>()
                .ForMember(dest => dest.TaxpareStoreId, opt => opt.MapFrom(src => src.Balance.TaxpayerStoreId))
                .ForMember(dest => dest.TaxpareStoreName, opt => opt.MapFrom(src => src.Balance.TaxpayerStore.StoreName))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.CalculateTotal()))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));
        }
    }
}
