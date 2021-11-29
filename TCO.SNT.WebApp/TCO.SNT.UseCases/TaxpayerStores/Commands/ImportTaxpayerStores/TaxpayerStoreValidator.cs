using FluentValidation;
using System;
using TCO.SNT.Common.Options;
using VsSdk.TaxpayerStore;

namespace TCO.SNT.UseCases.TaxpayerStores.Commands.ImportTaxpayerStores
{
    internal class TaxpayerStoreValidator : AbstractValidator<TaxpayerStore>
    {
        public TaxpayerStoreValidator(CompanyOptions options)
        {
            RuleFor(x => x.idSpecified).Equal(true);
            RuleFor(x => x.id).GreaterThan(0L);

            RuleFor(x => x.alcoholLicenseId).GreaterThan(0L).When(x => x.alcoholLicenseIdSpecified);
            RuleFor(x => x.alcoholLicenseId).Equal(0L).When(x => !x.alcoholLicenseIdSpecified);

            RuleFor(x => x.documentId).GreaterThan(0L).When(x => x.documentIdSpecified);
            RuleFor(x => x.documentId).Equal(0L).When(x => !x.documentIdSpecified);

            RuleFor(x => x.isCooperativeStore).Equal(false).When(x => !x.isCooperativeStoreSpecified);

            // Default store can not be deactivated 
            RuleFor(x => x.status).Equal(TaxpayerStoreStatus.VALID).When(x => x.isDefault);

            RuleFor(x => x.lesseeContractDate).Equal(DateTime.MinValue).When(x => !x.lesseeContractDateSpecified);
            RuleFor(x => x.lesseeContractDate)
                .Must(x => x.Kind == DateTimeKind.Local)
                .When(x => x.lesseeContractDateSpecified);

            RuleFor(x => x.oilOvdId).GreaterThan(0L).When(x => x.oilOvdIdSpecified);
            RuleFor(x => x.oilOvdId).Equal(0L).When(x => !x.oilOvdIdSpecified);

            // We do not support hierarchical stores for now
            RuleFor(x => x.parentIdSpecified).Equal(false);
            RuleFor(x => x.parentId).Equal(0L);

            RuleFor(x => x.responsiblePersonIin).NotEmpty();

            RuleFor(x => x.storeName).NotEmpty();
            
            RuleFor(x => x.tin).NotEmpty();
            RuleFor(x => x.tin).Equal(options.Tin);

            RuleFor(x => x.tobaccoOvdId).GreaterThan(0L).When(x => x.tobaccoOvdIdSpecified);
            RuleFor(x => x.tobaccoOvdId).Equal(0L).When(x => !x.tobaccoOvdIdSpecified);
        }
    }
}
