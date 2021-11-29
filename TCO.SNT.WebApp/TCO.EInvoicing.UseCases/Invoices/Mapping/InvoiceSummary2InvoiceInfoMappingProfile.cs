using AutoMapper;
using EsfApiSdk.Invoices;

namespace TCO.EInvoicing.UseCases.Invoices.Mapping
{
    internal class InvoiceSummary2InvoiceInfoMappingProfile : Profile
    {
        public InvoiceSummary2InvoiceInfoMappingProfile()
        {
            CreateMap<InvoiceSummary, Entities.InvoiceInfo>()
                .ForMember(dest => dest.LastUpdateDateUtc,
                    opt => opt.MapFrom(src => src.lastUpdateDate.ToUniversalTime()))
                .ForMember(dest => dest.InvoiceStatus,
                    opt => opt.MapFrom(src => src.invoiceStatus))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}
