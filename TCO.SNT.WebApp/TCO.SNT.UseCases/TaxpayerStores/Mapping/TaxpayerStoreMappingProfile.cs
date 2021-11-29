using AutoMapper;
using System;
using TCO.SNT.UseCases.GroupTaxpayerStores.Queries;
using TCO.SNT.UseCases.TaxpayerStores.Queries;
using VsSdk.TaxpayerStore;

namespace TCO.SNT.UseCases.TaxpayerStores.Mapping
{
    internal class TaxpayerStoreMappingProfile : Profile
    {
        public TaxpayerStoreMappingProfile()
        {
            CreateMap<Entities.TaxpayerStore, TaxpayerStoreSimpleDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.StoreTypeCode))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.StoreName));

            CreateMap<Entities.TaxpayerStore, TaxpayerStoreDescriptionDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.StoreName));

            CreateMap<TaxpayerStore, Entities.TaxpayerStore>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalId, opt => opt.Ignore())
                .ForMember(dest => dest.AlcoholLicenseId,
                    opt => opt.MapFrom(src => src.alcoholLicenseIdSpecified ? src.alcoholLicenseId : (long?)null))
                .ForMember(dest => dest.ExternalDocumentId,
                    opt => opt.MapFrom(src => src.documentIdSpecified ? src.documentId : (long?)null))
                .ForMember(dest => dest.IsCooperativeStore,
                    opt => opt.MapFrom(src => src.isCooperativeStoreSpecified ? src.isCooperativeStore : (bool?)null))
                .ForMember(dest => dest.IsRawMaterials,
                    opt => opt.MapFrom(src => src.isRawMaterialsSpecified ? src.isRawMaterials : (bool?)null))
                .ForMember(dest => dest.IsPublicStore,
                    opt => opt.MapFrom(src => src.isPublicStoreSpecified ? src.isPublicStore : (bool?)null))
                .ForMember(dest => dest.LesseeContractDateUtc,
                    opt => opt.MapFrom(src => src.lesseeContractDateSpecified ? src.lesseeContractDate.ToUniversalTime() : (DateTime?)null))
                .ForMember(dest => dest.OilOvdId,
                    opt => opt.MapFrom(src => src.oilOvdIdSpecified ? src.oilOvdId : (long?)null))
                .ForMember(dest => dest.ExternalParentId,
                    opt => opt.MapFrom(src => src.parentIdSpecified ? src.parentId : (long?)null))
                 .ForMember(dest => dest.TobaccoOvdId,
                    opt => opt.MapFrom(src => src.tobaccoOvdIdSpecified ? src.tobaccoOvdId : (long?)null));
        }
    }
}
