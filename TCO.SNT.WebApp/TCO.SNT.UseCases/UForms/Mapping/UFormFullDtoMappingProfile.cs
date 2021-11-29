using AutoMapper;
using System;
using TCO.SNT.Infrastructure.Interfaces;
using TCO.SNT.UseCases.UForms.Queries.GetAllUForms;
using TCO.SNT.UseCases.UForms.Queries.GetUFormFull;

namespace TCO.SNT.UseCases.UForms.Mapping
{
    internal class UFormFullDtoMappingProfile : Profile
    {
        public UFormFullDtoMappingProfile()
        {
            CreateMap<Entities.UForm, UFormSimpleDto>()
                .ForMember(dest => dest.RegistrationNumber, opt => opt.MapFrom(src => src.UFormInfo.RegistrationNumber))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.UFormInfo.Status))
                .ForMember(dest => dest.CancelReason, opt => opt.MapFrom(src => src.UFormInfo.CancelReason));

            CreateMap<Entities.UForm, UFormReport>()
                .ForMember(dest => dest.RegistrationNumber, opt => opt.MapFrom(src => src.UFormInfo.RegistrationNumber))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.UFormInfo.Status))
                .ForMember(dest => dest.LocalizedType, opt => opt.MapFrom(src => Resources.UFormTypeResource.ResourceManager.GetString(src.Type.ToString())))
                .ForMember(dest => dest.LocalizedStatus, opt => opt.MapFrom(src => Resources.UformStatusTypeResource.ResourceManager.GetString(src.UFormInfo.Status.ToString())))
                .ForMember(dest => dest.CancelReason, opt => opt.MapFrom(src => src.UFormInfo.CancelReason));

            CreateMap<Entities.UForm, UFormFullDto>()
                .IncludeMembers(q => q.UFormInfo)
                .ForMember(dest => dest.UFormId, opt => opt.MapFrom(src => src.Id));

            CreateMap<Entities.UFormInfo, UFormFullDto>()
                .ForMember(dest => dest.Date, opt => opt.Ignore())
                .ForMember(dest => dest.Number, opt => opt.Ignore())
                .ForMember(dest => dest.Sender, opt => opt.Ignore())
                .ForMember(dest => dest.Type, opt => opt.Ignore())
                .ForMember(dest => dest.TotalSum, opt => opt.Ignore())
                .ForMember(dest => dest.Products, opt => opt.Ignore())
                .ForMember(dest => dest.Comment, opt => opt.Ignore())
                .ForMember(dest => dest.WriteOffReason, opt => opt.Ignore())
                .ForMember(dest => dest.InputDate, opt =>
                {
                    opt.PreCondition(src => src.InputDateUtc.HasValue);
                    opt.MapFrom(src => (DateTime?)src.InputDateUtc.Value.UtcDateTime);
                })
                .ForMember(dest => dest.LastUpdateDate, opt =>
                {
                    opt.PreCondition(src => src.LastUpdateDateUtc.HasValue);
                    opt.MapFrom(src => (DateTime?)src.LastUpdateDateUtc.Value.UtcDateTime);
                })
                .ForMember(dest => dest.RecipientTaxpayerStoreId, opt => opt.MapFrom(src => src.UForm.Recipient.TaxpayerStoreId));

            CreateMap<Entities.UFormSender, UFormSenderDto>()
                .ForMember(dest => dest.StoreId, opt => opt.MapFrom(src => src.TaxpayerStoreId))
                .ForMember(dest => dest.StoreName, opt => opt.MapFrom(src => src.TaxpayerStore.StoreName));

            CreateMap<Entities.UFormProduct, UFormProductDto>()
             .ForMember(dest => dest.GsvsCode, opt => opt.MapFrom(src => src.ExternalGsvsCode));
        }
    }
}
