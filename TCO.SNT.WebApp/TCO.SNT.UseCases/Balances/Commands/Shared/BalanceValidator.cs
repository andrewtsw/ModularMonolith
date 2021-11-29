using FluentValidation;
using TCO.SNT.Common.Options;
using VsSdk.VstoreBalance;

namespace TCO.SNT.UseCases.Balances.Commands.Shared
{
    internal class BalanceValidator : AbstractValidator<Balance>
    {
        public BalanceValidator(CompanyOptions options)
        {
            RuleFor(x => x.balanceId).GreaterThan(0L);
            
            RuleFor(x => x.tin).NotEmpty();
            RuleFor(x => x.tin).Equal(options.Tin);

            RuleFor(x => x.taxpayerStoreId).GreaterThan(0L);

            RuleFor(x => x.projectCode).GreaterThan(0L).When(x => x.projectCodeSpecified);
            RuleFor(x => x.projectCode).Equal(0L).When(x => !x.projectCodeSpecified);

            RuleFor(x => x.name).NotEmpty();

            RuleFor(x => x.kpvedCode).NotEmpty();

            RuleFor(x => x.tnvedCode).NotEmpty();

            // GtinCode is optional in API and business process. 

            // ProductId is optional in API but this field is requred in a business process
            // But there are 2 products on production where ProductId = 0 so we can not add this validation.

            RuleFor(x => x.measureUnitCode).NotEmpty();
            
            RuleFor(x => x.unitPrice).GreaterThanOrEqualTo(0m);

            RuleFor(x => x.spiritPercent).GreaterThan(0m).When(x => x.spiritPercentSpecified);
            RuleFor(x => x.spiritPercent).Equal(0m).When(x => !x.spiritPercentSpecified);

            RuleFor(x => x.reserveQuantity).Equal(0m).When(x => !x.reserveQuantitySpecified);

            // At least one of unitPrice or reserveQuantity sqhould be non zero. It is bisuness requrement.
            // There are 2 products on production where quantity = 0 and reserveQuantity = 0
            // So we can not add validation for this case.

            // quantity/reserveQuantity can be negative and positive for both: INCOME and OUTCOME operations.
            // because a "form cancel" operation implemented in this way. 
            // So we do not need any additional validation for quantity/reserveQuantity
        }
    }
}
