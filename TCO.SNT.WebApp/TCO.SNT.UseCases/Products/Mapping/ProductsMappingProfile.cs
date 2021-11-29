using AutoMapper;
using System;
using TCO.SNT.UseCases.Products.Queries.Shared;
using VsSdk.Dictionaries;

namespace TCO.SNT.UseCases.Products.Mapping
{
    internal class ProductsMappingProfile : Profile
    {
        public ProductsMappingProfile()
        {
            CreateMap<Gsvs, Entities.Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.EndDateUtc, 
                    opt => opt.MapFrom(src => src.endDateSpecified ? src.endDate.ToUniversalTime() : (DateTimeOffset?)null))
                .ForMember(dest => dest.ExternalId, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.IsCanSelect, opt => opt.MapFrom(src => src.isCanSelectSpecified ? src.isCanSelect : (bool?)null))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.isDeletedSpecified ? src.isDeleted : (bool?)null))
                .ForMember(dest => dest.IsUseInVstore, opt => opt.MapFrom(src => src.isUseInVstoreSpecified ? src.isUseInVstore : (bool?)null))
                .ForMember(dest => dest.IsWithdrawal, opt => opt.MapFrom(src => src.isWithdrawalSpecified ? src.isWithdrawal : (bool?)null))                
                .ForMember(dest => dest.KpvedTypeCode, opt => 
                    opt.MapFrom(src => src.kpvedTypeCodeSpecified ? (Entities.KpvedType)src.kpvedTypeCode : (Entities.KpvedType?)null))
                .ForMember(dest => dest.LastUpdateDateUtc, opt => opt.MapFrom(src => src.lastUpdateDate.ToUniversalTime()))
                .ForMember(dest => dest.StartDateUtc, opt => opt.MapFrom(src => src.startDate.ToUniversalTime()));

            CreateMap<Entities.Product, ProductDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.NameRu));
        }
    }
}
