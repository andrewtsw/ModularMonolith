using AutoMapper;
using EsfApiSdk.Invoices;
using System;
using System.Globalization;
using TCO.EInvoicing.EsfApi.Interfaces.Invoices.Models;

namespace TCO.EInvoicing.Application.EsfInvoices.Mapping
{
    internal class InvoiceV2ToInvoiceMappingProfile : Profile
    {
        public InvoiceV2ToInvoiceMappingProfile()
        {
            CreateMap<InvoiceInfo, Entities.InvoiceInfo>()
                .ForMember(dest => dest.InvoiceId, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore())
                .ForMember(dest => dest.InputDateUtc,
                    opt => opt.MapFrom(src => src.inputDate.ToUniversalTime()))
                .ForMember(dest => dest.LastUpdateDateUtc,
                    opt => opt.MapFrom(src => src.lastUpdateDate.ToUniversalTime()))
                .ForMember(dest => dest.DeliveryDate,
                    opt => opt.MapFrom(src => src.deliveryDateSpecified ? src.deliveryDate : (DateTime?)null))
                .ForMember(dest => dest.InvoiceStatus,
                    opt => opt.MapFrom(src => src.invoiceStatusSpecified ? (Entities.InvoiceStatus)src.invoiceStatus : (Entities.InvoiceStatus?)null));

            CreateMap<InvoiceV2, Entities.Invoice>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalId, opt => opt.Ignore())
                .ForMember(dest => dest.InvoiceInfo, opt => opt.Ignore())
                .ForMember(dest => dest.Direction, opt => opt.Ignore())
                .ForMember(dest => dest.Date,
                    opt => opt.MapFrom(src => DateTime.ParseExact(src.date, "dd.MM.yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.DeliveryDocDate,
                    opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.deliveryDocDate) 
                        ? DateTime.ParseExact(src.deliveryDocDate, "dd.MM.yyyy", CultureInfo.InvariantCulture)
                        : (DateTime?)null))
                .ForMember(dest => dest.TurnoverDate,
                    opt => opt.MapFrom(src => DateTime.ParseExact(src.turnoverDate, "dd.MM.yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.DatePaper,
                    opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.datePaper)
                        ? DateTime.ParseExact(src.datePaper, "dd.MM.yyyy", CultureInfo.InvariantCulture)
                        : (DateTime?)null))
                .ForMember(dest => dest.ReasonPaper,
                    opt => opt.MapFrom(src => src.reasonPaperSpecified ? (Entities.InvoicePaperReasonType)src.reasonPaper : (Entities.InvoicePaperReasonType?)null))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.productSet.products));

            CreateMap<RelatedInvoice, Entities.RelatedInvoice>()
                .ForMember(dest => dest.InvoiceId, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore())
                .ForMember(dest => dest.Date,
                    opt => opt.MapFrom(src => DateTime.ParseExact(src.date, "dd.MM.yyyy", CultureInfo.InvariantCulture)));

            CreateMap<Consignee, Entities.InvoiceConsignee>()
                .ForMember(dest => dest.InvoiceId, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore());

            CreateMap<Consignor, Entities.InvoiceConsignor>()
                .ForMember(dest => dest.InvoiceId, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore());

            CreateMap<Customer, Entities.InvoiceCustomer>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.InvoiceId, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore())
                .ForMember(dest => dest.ShareParticipation,
                    opt => opt.MapFrom(src => src.shareParticipationSpecified ? src.shareParticipation : (decimal?)null));

            CreateMap<Seller, Entities.InvoiceSeller>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.InvoiceId, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore())
                .ForMember(dest => dest.IsBranchNonResident,
                    opt => opt.MapFrom(src => src.isBranchNonResidentSpecified ? src.isBranchNonResident : (bool?)null))
                .ForMember(dest => dest.ShareParticipation,
                    opt => opt.MapFrom(src => src.shareParticipationSpecified ? src.shareParticipation : (decimal?)null));

            CreateMap<DeliveryTerm, Entities.InvoiceDeliveryTerm>()
                .ForMember(dest => dest.InvoiceId, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore())
                .ForMember(dest => dest.ContractDate,
                    opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.contractDate)
                        ? DateTime.ParseExact(src.contractDate, "dd.MM.yyyy", CultureInfo.InvariantCulture)
                        : (DateTime?)null))
                .ForMember(dest => dest.WarrantDate,
                    opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.warrantDate)
                        ? DateTime.ParseExact(src.warrantDate, "dd.MM.yyyy", CultureInfo.InvariantCulture)
                        : (DateTime?)null));

            CreateMap<PublicOffice, Entities.InvoicePublicOffice>()
               .ForMember(dest => dest.InvoiceId, opt => opt.Ignore())
               .ForMember(dest => dest.Invoice, opt => opt.Ignore());

            CreateMap<ProductSet, Entities.InvoiceProductSet>()
               .ForMember(dest => dest.InvoiceId, opt => opt.Ignore())
               .ForMember(dest => dest.Invoice, opt => opt.Ignore())
               .ForMember(dest => dest.CurrencyRate,
                    opt => opt.MapFrom(src => src.currencyRateSpecified ? src.currencyRate : (decimal?)null))
               .ForMember(dest => dest.NdsRateType,
                    opt => opt.MapFrom(src => src.ndsRateTypeSpecified ? (Entities.InvoiceNdsRateType)src.ndsRateType : (Entities.InvoiceNdsRateType?)null));

            CreateMap<Product, Entities.InvoiceProduct>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.InvoiceId, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore())
                .ForMember(dest => dest.MeasureUnitId, opt => opt.Ignore())
                .ForMember(dest => dest.MeasureUnit, opt => opt.Ignore())
                .ForMember(dest => dest.ExciseAmount,
                    opt => opt.MapFrom(src => src.exciseAmountSpecified ? src.exciseAmount : (decimal?)null))
                .ForMember(dest => dest.ExciseRate,
                    opt => opt.MapFrom(src => src.exciseRateSpecified ? src.exciseRate : (decimal?)null))
                 .ForMember(dest => dest.NdsRate,
                    opt => opt.MapFrom(src => src.ndsRateSpecified ? src.ndsRate : (decimal?)null))
                .ForMember(dest => dest.Quantity,
                    opt => opt.MapFrom(src => src.quantitySpecified ? src.quantity : (decimal?)null))
                .ForMember(dest => dest.TurnoverAdjustment,
                    opt => opt.MapFrom(src => src.turnoverAdjustmentSpecified ? src.turnoverAdjustment : (int?)null))
                .ForMember(dest => dest.UnitPrice,
                    opt => opt.MapFrom(src => src.unitPriceSpecified ? src.unitPrice : (decimal?)null));

        }
    }
}
