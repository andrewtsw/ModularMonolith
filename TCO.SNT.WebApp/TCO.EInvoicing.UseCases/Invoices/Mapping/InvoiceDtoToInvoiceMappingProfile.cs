
using AutoMapper;
using TCO.EInvoicing.UseCases.Invoices.Commands.SaveDraftInvoice;

namespace TCO.EInvoicing.Application.EsfInvoices.Mapping
{
    internal class InvoiceDtoToInvoiceMappingProfile : Profile
    {
        public InvoiceDtoToInvoiceMappingProfile()
        {
            CreateMap<InvoiceDto, Entities.Invoice>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalId, opt => opt.Ignore())
                .ForMember(dest => dest.InvoiceType, opt => opt.Ignore())
                .ForMember(dest => dest.InvoiceInfo, opt => opt.Ignore())
                .ForMember(dest => dest.Direction, opt => opt.Ignore())
                // Ignore calculated fields
                .ForMember(dest => dest.Date, opt => opt.Ignore())
                .ForMember(dest => dest.OperatorFullname, opt => opt.Ignore())
                // RelatedInvoice support will be added later
                .ForMember(dest => dest.RelatedInvoice, opt => opt.Ignore())
                // Ignore paper fields
                .ForMember(dest => dest.DatePaper, opt => opt.Ignore())
                .ForMember(dest => dest.ReasonPaper, opt => opt.Ignore())
                // Ignore navigation fields
                .ForMember(dest => dest.Sellers, opt => opt.Ignore())
                .ForMember(dest => dest.Customers, opt => opt.Ignore())
                .ForMember(dest => dest.PublicOffice, opt => opt.Ignore())
                .ForMember(dest => dest.ProductSet, opt => opt.Ignore())
                .ForMember(dest => dest.Products, opt => opt.Ignore())
                // Ignore eller info - I section
                .ForMember(dest => dest.SellerAgentAddress, opt => opt.Ignore())
                .ForMember(dest => dest.SellerAgentDocDate, opt => opt.Ignore())
                .ForMember(dest => dest.SellerAgentDocNum, opt => opt.Ignore())
                .ForMember(dest => dest.SellerAgentName, opt => opt.Ignore())
                .ForMember(dest => dest.SellerAgentTin, opt => opt.Ignore())
                // Ignore  Customer info - J section
                .ForMember(dest => dest.CustomerAgentAddress, opt => opt.Ignore())
                .ForMember(dest => dest.CustomerAgentDocDate, opt => opt.Ignore())
                .ForMember(dest => dest.CustomerAgentDocNum, opt => opt.Ignore())
                .ForMember(dest => dest.CustomerAgentName, opt => opt.Ignore())
                .ForMember(dest => dest.CustomerAgentTin, opt => opt.Ignore());

            CreateMap<InvoiceConsigneeDto, Entities.InvoiceConsignee>()
                .ForMember(dest => dest.InvoiceId, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore());

            CreateMap<InvoiceConsignorDto, Entities.InvoiceConsignor>()
                .ForMember(dest => dest.InvoiceId, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore());

            CreateMap<InvoiceCustomerDto, Entities.InvoiceCustomer>()
                // Ignore Id and Invoice navigation 
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.InvoiceId, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore())
                // Support for these fields can be added later
                .ForMember(dest => dest.ShareParticipation, opt => opt.Ignore());

            CreateMap<InvoiceSellerDto, Entities.InvoiceSeller>()
                // Ignore Id and Invoice navigation 
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.InvoiceId, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore())
                // Ignore Ndsca region
                .ForMember(dest => dest.NdscaBank, opt => opt.Ignore())
                .ForMember(dest => dest.NdscaBik, opt => opt.Ignore())
                .ForMember(dest => dest.NdscaIik, opt => opt.Ignore())
                .ForMember(dest => dest.NdscaKbe, opt => opt.Ignore())
                // Ignore data from company options
                .ForMember(dest => dest.Tin, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.Address, opt => opt.Ignore())
                .ForMember(dest => dest.CertificateNum, opt => opt.Ignore())
                .ForMember(dest => dest.CertificateSeries, opt => opt.Ignore())
                // Support for these fields can be added later
                .ForMember(dest => dest.BranchTin, opt => opt.Ignore())
                .ForMember(dest => dest.ReorganizedTin, opt => opt.Ignore())
                .ForMember(dest => dest.ShareParticipation, opt => opt.Ignore());

            CreateMap<InvoiceDeliveryTermDto, Entities.InvoiceDeliveryTerm>()
                .ForMember(dest => dest.InvoiceId, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore());

            CreateMap<InvoiceProductDto, Entities.InvoiceProduct>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.InvoiceId, opt => opt.Ignore())
                .ForMember(dest => dest.Invoice, opt => opt.Ignore())
                // Ignore calculated properties
                .ForMember(dest => dest.PriceWithoutTax, opt => opt.Ignore())
                .ForMember(dest => dest.NdsAmount, opt => opt.Ignore())
                .ForMember(dest => dest.TurnoverSize, opt => opt.Ignore())
                .ForMember(dest => dest.PriceWithTax, opt => opt.Ignore())
                // Ignore unused properties
                .ForMember(dest => dest.AdditionalUnitNomenclature, opt => opt.Ignore())
                .ForMember(dest => dest.ProductNumberInSnt, opt => opt.Ignore())
                .ForMember(dest => dest.TurnoverAdjustment, opt => opt.Ignore())
                .ForMember(dest => dest.TurnoverCode, opt => opt.Ignore())
                .ForMember(dest => dest.KpvedCode, opt => opt.Ignore())
                .ForMember(dest => dest.TnvedName, opt => opt.Ignore())
                // Ignore data from dictionaries
                .ForMember(dest => dest.UnitNomenclature, opt => opt.Ignore()) // measure unit
                .ForMember(dest => dest.CatalogTruId, opt => opt.Ignore()) // product or balance
                // Ignore ref to MeasureUnit
                .ForMember(dest => dest.MeasureUnitId, opt => opt.Ignore())
                .ForMember(dest => dest.MeasureUnit, opt => opt.Ignore());
        }
    }
}
