using AutoMapper;
using System;
using System.Globalization;
using TCO.SNT.Common.Extensions;
using TCO.SNT.Vstore.Interfaces.UForm;
using VsSdk.UForm;

namespace TCO.SNT.UseCases.UForms.Mapping
{
    internal class UFormMappingProfile : Profile
    {
        public UFormMappingProfile()
        {
            CreateMap<UFormInfo, Entities.UFormInfo>()
                .ForMember(dest => dest.UForm, opt => opt.Ignore())
                .ForMember(dest => dest.UFormId, opt => opt.Ignore())
                // Map UFormInfo fields
                .ForMember(dest => dest.InputDateUtc,
                    opt => opt.MapFrom(dest => dest.inputDateSpecified ? dest.inputDate.ToUniversalTime() : (DateTimeOffset?)null))
                .ForMember(dest => dest.LastUpdateDateUtc,
                    opt => opt.MapFrom(dest => dest.lastUpdateDateSpecified ? dest.lastUpdateDate.ToUniversalTime() : (DateTimeOffset?)null))
                .ForMember(dest => dest.SignatureValid,
                    opt => opt.MapFrom(dest => dest.signatureValidSpecified ? dest.signatureValid : (bool?)null));

            CreateMap<UForm, Entities.UForm>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalId, opt => opt.Ignore())
                .ForMember(dest => dest.UFormInfo, opt => opt.Ignore())
                // Map Abstract form fields
                .ForMember(dest => dest.Date,
                    opt => opt.MapFrom(src => DateTime.ParseExact(src.date, "dd.MM.yyyy", CultureInfo.InvariantCulture)))
                .ForMember(dest => dest.TotalSum, opt => opt.MapFrom(dest => dest.totalSumSpecified ? dest.totalSum : 0m))
                // Map UForm form fields
                .ForMember(dest => dest.DetailingType,
                    opt => opt.MapFrom(dest => dest.detailingTypeSpecified
                        ? (Entities.UFormDetailingType)dest.detailingType
                        : (Entities.UFormDetailingType?)null))
                .ForMember(dest => dest.ReorganizationType,
                    opt => opt.MapFrom(dest => dest.reorganizationTypeSpecified
                    ? (Entities.UFormReorganizationType)dest.reorganizationType
                    : (Entities.UFormReorganizationType?)null))
                .ForMember(dest => dest.SourceTotalSum,
                    opt => opt.MapFrom(dest => dest.sourceTotalSumSpecified ? dest.sourceTotalSum : 0m))
                .ForMember(dest => dest.WriteOffReason,
                    opt => opt.MapFrom(dest => dest.writeOffReasonSpecified
                    ? (Entities.UFormWriteOffType)dest.writeOffReason
                    : (Entities.UFormWriteOffType?)null))
                // TODO: SourceProducts support will be added later
                .ForMember(dest => dest.SourceProducts, opt => opt.Ignore());

            CreateMap<AbstractUFormParticipant, Entities.UFormParticipant>()
                .ForMember(dest => dest.TaxpayerStore, opt => opt.Ignore())
                .ForMember(dest => dest.TaxpayerStoreId, opt => opt.Ignore())
                .ForMember(dest => dest.UForm, opt => opt.Ignore())
                .ForMember(dest => dest.UFormId, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalStoreId, opt => opt.MapFrom(src => src.storeId));

            CreateMap<UFormSender, Entities.UFormSender>()
                .IncludeBase<AbstractUFormParticipant, Entities.UFormParticipant>();

            CreateMap<UFormRecipient, Entities.UFormRecipient>()
                .IncludeBase<AbstractUFormParticipant, Entities.UFormParticipant>();

            CreateMap<UFormProduct, Entities.UFormProduct>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.ProductForm, opt => opt.Ignore())
                .ForMember(dest => dest.ProductFormId, opt => opt.Ignore())
                .ForMember(dest => dest.SourceProductForm, opt => opt.Ignore())
                .ForMember(dest => dest.SourceProductFormId, opt => opt.Ignore())
                // Map AbstractUFormProduct fields
                .ForMember(dest => dest.MeasureUnit, opt => opt.Ignore())
                .ForMember(dest => dest.MeasureUnitId, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalMeasureUnitCode, opt => opt.MapFrom(src => src.measureUnitCode))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(dest => dest.priceSpecified ? dest.price : 0m))
                .ForMember(dest => dest.Sum, opt => opt.MapFrom(dest => dest.sumSpecified ? dest.sum : 0m))
                // Map UFormProduct fields
                .ForMember(dest => dest.Balance, opt => opt.Ignore())
                .ForMember(dest => dest.BalanceId, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalProductId,
                    opt => opt.MapFrom(src => src.productIdSpecified ? src.productId : (long?)null))
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.ProductId, opt => opt.Ignore())
                .ForMember(dest => dest.ExternalGsvsCode, opt => opt.MapFrom(src => src.gsvsCode))
                .ForMember(dest => dest.CanExport,
                    opt => opt.MapFrom(dest => dest.canExportSpecified ? dest.canExport : (bool?)null))
                .ForMember(dest => dest.DutyTypeCode,
                    opt => opt.MapFrom(dest => dest.dutyTypeCodeSpecified
                        ? (Entities.UFormCustomsDutyType)dest.dutyTypeCode
                        : (Entities.UFormCustomsDutyType?)null))
                .ForMember(dest => dest.SpiritPercent,
                    opt => opt.MapFrom(src => src.spiritPercentSpecified ? src.spiritPercent : (decimal?)null));

            CreateMap<Entities.UForm, UForm>()
                // Map Abstract form fields
                .ForMember(dest => dest.date, opt => opt.MapFrom(src => src.Date.ToStringCommonDateFormat()))
                // We have to remove all trailing zeros from decimal values because ESF API does not support it.
                .ForMember(dest => dest.totalSum, opt => opt.MapFrom(src => src.TotalSum.RemoveTrailingZeros()))
                .ForMember(dest => dest.totalSumSpecified, opt => opt.MapFrom(src => true))
                // Map UFormInfo fields
                .ForMember(dest => dest.detailingTypeSpecified, opt => opt.MapFrom(src => src.DetailingType.HasValue))
                .ForMember(dest => dest.reorganizationTypeSpecified, opt => opt.MapFrom(src => src.ReorganizationType.HasValue))
                .ForMember(dest => dest.writeOffReasonSpecified, opt => opt.MapFrom(src => src.WriteOffReason.HasValue))
                // TODO: SourceProducts support will be added later
                .ForMember(dest => dest.sourceProducts, opt => opt.Ignore())
                .ForMember(dest => dest.sourceTotalSumSpecified, opt => opt.Ignore())
                .ForMember(dest => dest.sourceTotalSum, opt => opt.Ignore());

            CreateMap<Entities.UFormParticipant, AbstractUFormParticipant>()
                .ForMember(dest => dest.storeId, opt => opt.MapFrom(src => src.ExternalStoreId))
                .ForMember(dest => dest.storeIdSpecified, opt => opt.MapFrom(src => true));

            CreateMap<Entities.UFormSender, UFormSender>()
                .IncludeBase<Entities.UFormParticipant, AbstractUFormParticipant>();

            CreateMap<Entities.UFormRecipient, UFormRecipient>()
                .IncludeBase<Entities.UFormParticipant, AbstractUFormParticipant>();

            CreateMap<Entities.UFormProduct, UFormProduct>()
                // Map AbstractUFormProduct fields
                .ForMember(dest => dest.gsvsCode, opt => opt.MapFrom(src => src.ExternalGsvsCode))
                .ForMember(dest => dest.measureUnitCode, opt => opt.MapFrom(src => src.MeasureUnit.Code))
                .ForMember(dest => dest.priceSpecified, opt => opt.MapFrom(src => src.Price > 0m))
                .ForMember(dest => dest.price, opt => opt.MapFrom(src => src.Price.RemoveTrailingZeros()))
                .ForMember(dest => dest.quantity, opt => opt.MapFrom(src => src.Quantity.RemoveTrailingZeros()))
                .ForMember(dest => dest.sumSpecified, opt => opt.MapFrom(src => src.Sum > 0m))
                .ForMember(dest => dest.sum, opt => opt.MapFrom(src => src.Sum.RemoveTrailingZeros()))
                // Map UFormProduct fields
                .ForMember(dest => dest.canExportSpecified, opt => opt.MapFrom(src => src.CanExport.HasValue))
                .ForMember(dest => dest.dutyTypeCodeSpecified, opt => opt.MapFrom(src => src.DutyTypeCode.HasValue))
                .ForMember(dest => dest.productId, opt => opt.MapFrom(src => src.ExternalProductId))
                .ForMember(dest => dest.productIdSpecified, opt => opt.MapFrom(src => src.ExternalProductId.HasValue))
                .ForMember(dest => dest.spiritPercentSpecified, opt => opt.MapFrom(src => src.SpiritPercent.HasValue));

        }
    }
}
