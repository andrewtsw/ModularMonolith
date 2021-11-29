using AutoMapper;
using System;
using System.Globalization;
using TCO.SNT.EsfApi.Interfaces.Snt;

namespace TCO.SNT.UseCases.Snt.Mapping
{
    internal class SntV12SntMappingProfile : Profile
    {
        public SntV12SntMappingProfile()
        {
            CreateMap<SntV1, Entities.Snt>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalId, opt => opt.Ignore())
                .ForMember(dest => dest.SntInfo, opt => opt.Ignore())
                .ForMember(dest => dest.AcceptanceGoodsInfo, opt => opt.Ignore())
                .ForMember(dest => dest.DocumentInfo, opt => opt.Ignore())
                .ForMember(dest => dest.OgdMarksInfo, opt => opt.Ignore())
                // AbstractSnt
                .ForMember(dest => dest.Date, opt =>
                    opt.MapFrom(src => DateTime.ParseExact(src.date, "dd.MM.yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.ShippingDate,
                    opt => opt.MapFrom(src => DateTime.ParseExact(src.shippingDate, "dd.MM.yyyy", CultureInfo.InvariantCulture)))
                // SntV1
                .ForMember(dest => dest.DatePaper,
                    opt => opt.MapFrom(src => DateTime.ParseExact(src.datePaper, "dd.MM.yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.ReasonPaper,
                    opt => opt.MapFrom(src => src.reasonPaperSpecified ? (Entities.SntPaperReasonType)src.reasonPaper : (Entities.SntPaperReasonType?)null))
                .ForMember(dest => dest.DigitalMarkingNotificationDate,
                    opt => opt.MapFrom(src => DateTime.ParseExact(src.digitalMarkingNotificationDate, "dd.MM.yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.ImportType,
                    opt => opt.MapFrom(src => src.sntImport != null ? src.sntImport.importType : (SntImportType?)null))
                .ForMember(dest => dest.ExternalImportSezCode,
                    opt => opt.MapFrom(src => src.sntImport.sezCodeSpecified ? src.sntImport.sezCode : (long?)null))
                .ForMember(dest => dest.ExportType,
                    opt => opt.MapFrom(src => src.sntExport != null ? src.sntExport.exportType : (SntExportType?)null))
                .ForMember(dest => dest.ExternalExportSezCode,
                    opt => opt.MapFrom(src => src.sntExport.sezCodeSpecified ? src.sntExport.sezCode : (long?)null))
                .ForMember(dest => dest.TransferType,
                    opt => opt.MapFrom(src => src.transferTypeSpecified ? (Entities.SntTransferType)src.transferType : (Entities.SntTransferType?)null))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.productSet.products))
                .ForMember(dest => dest.OilProducts, opt => opt.MapFrom(src => src.oilSet.products))
                .ForMember(dest => dest.CurrencyRate,
                    opt => opt.MapFrom(src => src.currencyRateSpecified ? src.currencyRate : (decimal?)null))
                .ForMember(dest => dest.MptId,
                    opt => opt.MapFrom(src => src.mptIdSpecified ? src.mptId : (long?)null))
                .ForMember(dest => dest.Comment, opt => opt.Ignore());

            CreateMap<SntConsignee, Entities.SntConsignee>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore())
                .ForMember(dest => dest.NonResident,
                    opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.nonResident) && bool.Parse(src.nonResident)));

            CreateMap<SntConsignor, Entities.SntConsignor>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore())
                .ForMember(dest => dest.NonResident,
                    opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.nonResident) && bool.Parse(src.nonResident)));

            CreateMap<SntContract, Entities.SntContract>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore())
                .ForMember(dest => dest.IsContract, opt => opt.MapFrom(src => bool.Parse(src.isContract)))
                .ForMember(dest => dest.Date,
                    opt => opt.MapFrom(src => DateTime.ParseExact(src.date, "dd.MM.yyyy", CultureInfo.InvariantCulture)));

            CreateMap<SntCustomer, Entities.SntCustomer>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore())
                .ForMember(dest => dest.TaxpayerStoreId, opt => opt.Ignore())
                .ForMember(dest => dest.TaxpayerStore, opt => opt.Ignore())
                .ForMember(dest => dest.NonResident,
                    opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.nonResident) && bool.Parse(src.nonResident)))
                .ForMember(dest => dest.ExternalStoreId,
                    opt => opt.MapFrom(src => src.storeIdSpecified ? src.storeId : (long?)null));

            CreateMap<SntSeller, Entities.SntSeller>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore())
                .ForMember(dest => dest.TaxpayerStoreId, opt => opt.Ignore())
                .ForMember(dest => dest.TaxpayerStore, opt => opt.Ignore())
                .ForMember(dest => dest.NonResident,
                    opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.nonResident) && bool.Parse(src.nonResident)))
                .ForMember(dest => dest.ExternalStoreId,
                    opt => opt.MapFrom(src => src.storeIdSpecified ? src.storeId : (long?)null));

            CreateMap<SntShippingInfo, Entities.SntShippingInfo>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore())
                .ForMember(dest => dest.NonResident,
                    opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.nonResident) && bool.Parse(src.nonResident)));

            CreateMap<SntCarCargoInfo, Entities.SntCarCargoInfo>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore());

            CreateMap<SntBaseProductV1, Entities.SntProductBase>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore())
                .ForMember(dest => dest.MeasureUnitId, opt => opt.Ignore())
                .ForMember(dest => dest.MeasureUnit, opt => opt.Ignore())
                .ForMember(dest => dest.BalanceId, opt => opt.Ignore())
                .ForMember(dest => dest.Balance, opt => opt.Ignore())
                .ForMember(dest => dest.Gsvs, opt => opt.Ignore())
                .ForMember(dest => dest.GsvsId, opt => opt.Ignore())
                .ForMember(dest => dest.ExciseAmount,
                    opt => opt.MapFrom(src => src.exciseAmountSpecified ? src.exciseAmount : (decimal?)null))
                .ForMember(dest => dest.ExciseRate,
                    opt => opt.MapFrom(src => src.exciseRateSpecified ? src.exciseRate : (decimal?)null))
                .ForMember(dest => dest.NdsAmount,
                    opt => opt.MapFrom(src => src.ndsAmountSpecified ? src.ndsAmount : (decimal?)null))
                .ForMember(dest => dest.NdsRate,
                    opt => opt.MapFrom(src => src.ndsRateSpecified ? src.ndsRate : (int?)null));

            CreateMap<SntProduct, Entities.SntProduct>()
                .IncludeBase<SntBaseProductV1, Entities.SntProductBase>()
                .ForMember(dest => dest.ExternalMeasureUnitCode, opt => opt.MapFrom(src => src.measureUnitCode));

            CreateMap<SntOilProduct, Entities.SntOilProduct>()
               .IncludeBase<SntBaseProductV1, Entities.SntProductBase>()
               .ForMember(dest => dest.ExternalMeasureUnitCode, opt => opt.MapFrom(src => src.measureUnitCode));

            CreateMap<SntBaseProductSetV1, Entities.SntProductSetBase>()
               .ForMember(dest => dest.SntId, opt => opt.Ignore())
               .ForMember(dest => dest.Snt, opt => opt.Ignore())
                .ForMember(dest => dest.TotalExciseAmount,
                    opt => opt.MapFrom(src => src.totalExciseAmountSpecified ? src.totalExciseAmount : (decimal?)null))
                .ForMember(dest => dest.TotalNdsAmount,
                    opt => opt.MapFrom(src => src.totalNdsAmountSpecified ? src.totalNdsAmount : (decimal?)null))
                .ForMember(dest => dest.TotalPriceWithTax,
                    opt => opt.MapFrom(src => src.totalPriceWithTaxSpecified ? src.totalPriceWithTax : (decimal?)null));

            CreateMap<SntProductSet, Entities.SntProductSet>()
                .IncludeBase<SntBaseProductSetV1, Entities.SntProductSetBase>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore());

            CreateMap<SntOilSet, Entities.SntOilSet>()
                .IncludeBase<SntBaseProductSetV1, Entities.SntProductSetBase>()
                .ForMember(dest => dest.SntId, opt => opt.Ignore())
                .ForMember(dest => dest.Snt, opt => opt.Ignore());
        }
    }
}
