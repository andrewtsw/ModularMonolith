using AutoMapper;
using TCO.EInvoicing.Entities;
using TCO.EInvoicing.UseCases.Invoices.Dto;

namespace TCO.EInvoicing.UseCases.Invoices.Mapping
{
    internal class Invoice2InvoiceFullDtoMappingProfile : Profile
    {
        public Invoice2InvoiceFullDtoMappingProfile()
        {
            CreateMap<Invoice, InvoiceFullDto>()
                .ForMember(dest => dest.RegistrationNumber,
                    opt => opt.MapFrom(src => src.InvoiceInfo.RegistrationNumber))
                .ForAllOtherMembers(x => x.Ignore()); // TODO remove
        }
    }
}
