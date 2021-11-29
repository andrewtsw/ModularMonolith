
using AutoMapper;
using TCO.EInvoicing.EsfApi.Interfaces.Invoices.Models;
using TCO.SNT.Common.Extensions;

namespace TCO.EInvoicing.UseCases.Invoices.Mapping
{
    public class Invoice2InvoiceV2MappingProfile: Profile
    {
        public Invoice2InvoiceV2MappingProfile()
        {
            CreateMap<Entities.Invoice, InvoiceV2>()
                .ForMember(dest => dest.turnoverDate, opt => opt.MapFrom(src => src.TurnoverDate.ToStringCommonDateFormat()))
                .ForMember(dest => dest.deliveryDocDate, opt => opt.MapFrom(src =>src.DeliveryDocDate.HasValue ?  src.DeliveryDocDate.Value.ToStringCommonDateFormat() : null))
                .ForMember(dest => dest.reasonPaperSpecified, opt => opt.Ignore())
                .ForMember(dest => dest.date, opt => opt.MapFrom(src => src.Date.ToStringCommonDateFormat()))
                .ForMember(dest => dest.customerParticipants, opt => opt.Ignore())
                .ForMember(dest => dest.sellerParticipants, opt => opt.Ignore());

            CreateMap<Entities.InvoicePublicOffice, PublicOffice>();

            CreateMap<Entities.RelatedInvoice, RelatedInvoice>();
            
            CreateMap<Entities.InvoiceCustomer, Customer>()
                .ForMember(dest => dest.shareParticipationSpecified, opt => opt.MapFrom(src => src.ShareParticipation.HasValue))
                .ForMember(dest => dest.statuses, opt =>
                {
                    opt.AllowNull();
                    opt.MapFrom(src => !src.Statuses.IsNullOrEmpty() ? src.Statuses : null);
                });

            CreateMap<Entities.InvoiceSeller, Seller>()
                .ForMember(dest => dest.isBranchNonResidentSpecified, opt => opt.MapFrom(src => src.IsBranchNonResident.HasValue))
                .ForMember(dest => dest.shareParticipationSpecified, opt => opt.MapFrom(src => src.ShareParticipation.HasValue))
                .ForMember(dest => dest.statuses, opt =>
                {
                    opt.AllowNull();
                    opt.MapFrom(src => !src.Statuses.IsNullOrEmpty() ? src.Statuses : null);
                });

            CreateMap<Entities.InvoiceConsignee, Consignee>();

            CreateMap<Entities.InvoiceConsignor, Consignor>();

            CreateMap<Entities.InvoiceDeliveryTerm, DeliveryTerm>()
                .ForMember(dest => dest.contractDate, opt => opt.MapFrom(src => src.ContractDate.HasValue ? src.ContractDate.Value.ToStringCommonDateFormat() : null));

            CreateMap<Entities.InvoiceProductSet, ProductSet>()
                .ForMember(dest => dest.products, opt => opt.MapFrom(src => src.Invoice.Products))
                .ForMember(dest => dest.currencyRate, opt => opt.MapFrom(src => (src.CurrencyRate ?? 0m).RemoveTrailingZeros()))
                .ForMember(dest => dest.currencyRateSpecified, opt => opt.MapFrom(src => src.CurrencyRate.HasValue))
                .ForMember(dest => dest.totalExciseAmount, opt => opt.MapFrom(src => (src.TotalExciseAmount ?? 0m).RemoveTrailingZeros()))
                .ForMember(dest => dest.totalTurnoverSize, opt => opt.MapFrom(src => src.TotalTurnoverSize.RemoveTrailingZeros()))
                .ForMember(dest => dest.totalPriceWithTax, opt => opt.MapFrom(src => src.TotalPriceWithTax.RemoveTrailingZeros()))
                .ForMember(dest => dest.totalPriceWithoutTax, opt => opt.MapFrom(src => src.TotalPriceWithoutTax.RemoveTrailingZeros()))
                .ForMember(dest => dest.totalNdsAmount, opt => opt.MapFrom(src => (src.TotalNdsAmount ?? 0m).RemoveTrailingZeros()))
                .ForMember(dest => dest.ndsRateTypeSpecified, opt => opt.MapFrom(src => src.NdsRateType.HasValue));

            CreateMap<Entities.InvoiceProduct, Product>()
                .ForMember(dest => dest.exciseAmount, opt => opt.MapFrom(src => (src.ExciseAmount ?? 0m).RemoveTrailingZeros()))
                .ForMember(dest => dest.exciseAmountSpecified, opt => opt.MapFrom(src => src.ExciseAmount.HasValue))
                .ForMember(dest => dest.exciseRate, opt => opt.MapFrom(src => (src.ExciseRate ?? 0m).RemoveTrailingZeros()))
                .ForMember(dest => dest.exciseRateSpecified, opt => opt.MapFrom(src => src.ExciseRate.HasValue))
                .ForMember(dest => dest.ndsRate, opt => opt.MapFrom(src => src.NdsRate))
                .ForMember(dest => dest.ndsRateSpecified, opt => opt.MapFrom(src => src.NdsRate.HasValue))
                .ForMember(dest => dest.quantity, opt => opt.MapFrom(src => (src.Quantity ?? 0m).RemoveTrailingZeros()))
                .ForMember(dest => dest.quantitySpecified, opt => opt.MapFrom(src => src.Quantity.HasValue))
                .ForMember(dest => dest.turnoverAdjustment, opt => opt.MapFrom(src => (src.TurnoverAdjustment ?? 0)))
                .ForMember(dest => dest.turnoverAdjustmentSpecified, opt => opt.MapFrom(src => src.TurnoverAdjustment.HasValue))
                .ForMember(dest => dest.unitPrice, opt => opt.MapFrom(src => (src.UnitPrice ?? 0m).RemoveTrailingZeros()))
                .ForMember(dest => dest.unitPriceSpecified, opt => opt.MapFrom(src => src.UnitPrice.HasValue))
                .ForMember(dest => dest.priceWithoutTax, opt => opt.MapFrom(src => src.PriceWithoutTax.RemoveTrailingZeros()))
                .ForMember(dest => dest.priceWithTax, opt => opt.MapFrom(src => src.PriceWithTax.RemoveTrailingZeros()))
                .ForMember(dest => dest.turnoverSize, opt => opt.MapFrom(src => src.TurnoverSize.RemoveTrailingZeros()))
                .ForMember(dest => dest.ndsAmount, opt => opt.MapFrom(src => (src.NdsAmount ?? 0m).RemoveTrailingZeros()));

        }
    }
}
