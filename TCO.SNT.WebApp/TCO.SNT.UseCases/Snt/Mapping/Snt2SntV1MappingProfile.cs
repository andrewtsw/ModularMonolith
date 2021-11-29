using AutoMapper;
using System.Xml;
using TCO.SNT.Common.Extensions;
using TCO.SNT.EsfApi.Interfaces.Snt;

namespace TCO.SNT.UseCases.Snt.Mapping
{
    internal class Snt2SntV1MappingProfile : Profile
    {
        public Snt2SntV1MappingProfile()
        {
            CreateMap<Entities.Snt, SntV1>()
                // Ignored sectinos
                .ForMember(dest => dest.alcoholSet, opt => opt.Ignore())
                .ForMember(dest => dest.biofuelSet, opt => opt.Ignore())
                .ForMember(dest => dest.directoryInfo, opt => opt.Ignore())
                .ForMember(dest => dest.exportControlProductSet, opt => opt.Ignore())
                .ForMember(dest => dest.fillingOfAircraft, opt => opt.Ignore())
                .ForMember(dest => dest.otherProductWithDigitalMarkSet, opt => opt.Ignore())
                .ForMember(dest => dest.releaseGoodsInfo, opt => opt.Ignore())
                .ForMember(dest => dest.sharingParticipantContract, opt => opt.Ignore())
                .ForMember(dest => dest.tobaccoSet, opt => opt.Ignore())
                // SntExport
                .ForMember(dest => dest.sntExport,
                    opt => opt.MapFrom(src => src.ExportType.HasValue ?
                    new SntExport
                    {
                        exportType = (SntExportType)src.ExportType.Value,
                        sezCode = src.ExternalExportSezCode ?? 0L,
                        sezCodeSpecified = src.ExternalExportSezCode.HasValue
                    } : null))
                // SntImport
                .ForMember(dest => dest.sntImport,
                    opt => opt.MapFrom(src => src.ImportType.HasValue ?
                    new SntImport
                    {
                        importType = (SntImportType)src.ImportType.Value,
                        sezCode = src.ExternalImportSezCode ?? 0L,
                        sezCodeSpecified = src.ExternalImportSezCode.HasValue
                    } : null))
                // CurrencyRate
                .ForMember(dest => dest.currencyRate, opt => opt.MapFrom(src => (src.CurrencyRate ?? 0m).RemoveTrailingZeros()))
                .ForMember(dest => dest.currencyRateSpecified, opt => opt.MapFrom(src => src.CurrencyRate.HasValue))
                // Specified properties
                .ForMember(dest => dest.transferTypeSpecified, opt => opt.MapFrom(src => src.TransferType.HasValue))
                .ForMember(dest => dest.reasonPaperSpecified, opt => opt.MapFrom(src => src.ReasonPaper.HasValue))
                // Dates
                .ForMember(dest => dest.date,
                    opt => opt.MapFrom(src => src.Date.Value.ToStringCommonDateFormat()))
                .ForMember(dest => dest.shippingDate,
                    opt =>
                    {
                        opt.PreCondition(src => src.ShippingDate.HasValue);
                        opt.MapFrom(src => src.ShippingDate.Value.ToStringCommonDateFormat());
                    })
                .ForMember(dest => dest.datePaper,
                    opt => opt.MapFrom(src => src.DatePaper.HasValue ? src.DatePaper.Value.ToStringCommonDateFormat() : null))
                .ForMember(dest => dest.digitalMarkingNotificationDate,
                    opt => opt.MapFrom(src => src.DigitalMarkingNotificationDate.HasValue ? src.DigitalMarkingNotificationDate.Value.ToStringCommonDateFormat() : null))
                // Ignore mptId because it does not used for now
                .ForMember(dest => dest.mptId, opt => opt.Ignore())
                .ForMember(dest => dest.mptIdSpecified, opt => opt.Ignore());

            CreateMap<Entities.SntConsignee, SntConsignee>()
                .ForMember(dest => dest.nonResident, opt => opt.MapFrom(src => XmlConvert.ToString(src.NonResident)));

            CreateMap<Entities.SntConsignor, SntConsignor>()
                .ForMember(dest => dest.nonResident, opt => opt.MapFrom(src => XmlConvert.ToString(src.NonResident)));

            CreateMap<Entities.SntContract, SntContract>()
                .ForMember(dest => dest.isContract, opt => opt.MapFrom(src => XmlConvert.ToString(src.IsContract)))
                .ForMember(dest => dest.date,
                    opt => opt.MapFrom(src => src.Date.HasValue ? src.Date.Value.ToStringCommonDateFormat() : null));

            CreateMap<Entities.SntCustomer, SntCustomer>()
                .ForMember(dest => dest.nonResident, opt => opt.MapFrom(src => XmlConvert.ToString(src.NonResident)))
                .ForMember(dest => dest.storeId, opt => opt.MapFrom(src => src.ExternalStoreId ?? 0L))
                .ForMember(dest => dest.storeIdSpecified, opt => opt.MapFrom(src => src.ExternalStoreId.HasValue))
                .ForMember(dest => dest.statuses, opt =>
                {
                    opt.AllowNull();
                    opt.MapFrom(src => !src.Statuses.IsNullOrEmpty() ? src.Statuses : null);
                });

            CreateMap<Entities.SntSeller, SntSeller>()
                .ForMember(dest => dest.nonResident, opt => opt.MapFrom(src => XmlConvert.ToString(src.NonResident)))
                .ForMember(dest => dest.storeId, opt => opt.MapFrom(src => src.ExternalStoreId ?? 0L))
                .ForMember(dest => dest.storeIdSpecified, opt => opt.MapFrom(src => src.ExternalStoreId.HasValue))
                .ForMember(dest => dest.statuses, opt =>
                {
                    opt.AllowNull();
                    opt.MapFrom(src => !src.Statuses.IsNullOrEmpty() ? src.Statuses : null);
                });

            CreateMap<Entities.SntCarCargoInfo, SntCarCargoInfo>()
                // Ignore collections because we use only driver info for now.
                .ForMember(dest => dest.cargoInfo, opt => opt.Ignore())
                .ForMember(dest => dest.loadingUnloadingInfo, opt => opt.Ignore())
                .ForMember(dest => dest.otherInfo, opt => opt.Ignore())
                .ForMember(dest => dest.taxInfo, opt => opt.Ignore());

            CreateMap<Entities.SntShippingInfo, SntShippingInfo>()
                .ForMember(dest => dest.nonResident, opt => opt.MapFrom(src => XmlConvert.ToString(src.NonResident)));

            CreateMap<Entities.SntProductSetBase, SntBaseProductSetV1>()
                .ForMember(dest => dest.totalExciseAmount,
                    opt => opt.MapFrom(src => (src.TotalExciseAmount ?? 0m).RemoveTrailingZeros()))
                .ForMember(dest => dest.totalExciseAmountSpecified, opt => opt.MapFrom(src => src.TotalExciseAmount.HasValue))
                .ForMember(dest => dest.totalNdsAmount,
                    opt => opt.MapFrom(src => (src.TotalNdsAmount ?? 0m).RemoveTrailingZeros()))
                .ForMember(dest => dest.totalNdsAmountSpecified, opt => opt.MapFrom(src => src.TotalNdsAmount.HasValue))
                .ForMember(dest => dest.totalPriceWithTax,
                    opt => opt.MapFrom(src => (src.TotalPriceWithTax ?? 0m).RemoveTrailingZeros()))
                .ForMember(dest => dest.totalPriceWithTaxSpecified, opt => opt.MapFrom(src => src.TotalPriceWithTax.HasValue))
                .ForMember(dest => dest.totalPriceWithoutTax, opt => opt.MapFrom(src => src.TotalPriceWithoutTax.RemoveTrailingZeros()));

            CreateMap<Entities.SntProductSet, SntProductSet>()
                .IncludeBase<Entities.SntProductSetBase, SntBaseProductSetV1>()
                .ForMember(dest => dest.products, opt => opt.MapFrom(src => src.Snt.Products));

            CreateMap<Entities.SntOilSet, SntOilSet>()
                .IncludeBase<Entities.SntProductSetBase, SntBaseProductSetV1>()
                .ForMember(dest => dest.products, opt => opt.MapFrom(src => src.Snt.OilProducts));

            CreateMap<Entities.SntProductBase, SntBaseProductV1>()
                .ForMember(dest => dest.exciseAmount, opt => opt.MapFrom(src => (src.ExciseAmount ?? 0m).RemoveTrailingZeros()))
                .ForMember(dest => dest.exciseAmountSpecified, opt => opt.MapFrom(src => src.ExciseAmount.HasValue))
                .ForMember(dest => dest.exciseRate, opt => opt.MapFrom(src => (src.ExciseRate ?? 0m).RemoveTrailingZeros()))
                .ForMember(dest => dest.exciseRateSpecified, opt => opt.MapFrom(src => src.ExciseRate.HasValue))
                .ForMember(dest => dest.ndsAmount, opt => opt.MapFrom(src => (src.NdsAmount ?? 0m).RemoveTrailingZeros()))
                .ForMember(dest => dest.ndsAmountSpecified, opt => opt.MapFrom(src => src.NdsAmount.HasValue))
                .ForMember(dest => dest.ndsRate, opt => opt.MapFrom(src => src.NdsRate ?? 0))
                .ForMember(dest => dest.ndsRateSpecified, opt => opt.MapFrom(src => src.NdsRate.HasValue))
                .ForMember(dest => dest.priceWithoutTax, opt => opt.MapFrom(src => src.PriceWithoutTax.RemoveTrailingZeros()))
                .ForMember(dest => dest.priceWithTax, opt => opt.MapFrom(src => src.PriceWithTax.RemoveTrailingZeros()));

            CreateMap<Entities.SntProduct, SntProduct>()
                .IncludeBase<Entities.SntProductBase, SntBaseProductV1>()
                .ForMember(dest => dest.measureUnitCode, opt => opt.MapFrom(src => src.ExternalMeasureUnitCode))
                .ForMember(dest => dest.price, opt => opt.MapFrom(src => src.Price.RemoveTrailingZeros()))
                .ForMember(dest => dest.quantity, opt => opt.MapFrom(src => src.Quantity.RemoveTrailingZeros()));

            CreateMap<Entities.SntOilProduct, SntOilProduct>()
                .IncludeBase<Entities.SntProductBase, SntBaseProductV1>()
                .ForMember(dest => dest.measureUnitCode, opt => opt.MapFrom(src => src.ExternalMeasureUnitCode))
                .ForMember(dest => dest.price, opt => opt.MapFrom(src => src.Price.RemoveTrailingZeros()))
                .ForMember(dest => dest.quantity, opt => opt.MapFrom(src => src.Quantity.RemoveTrailingZeros()));
        }
    }
}
