using EsfApiSdk.Snt;
using FluentValidation;

namespace TCO.SNT.UseCases.Snt.Commands.Import.Validators
{
    internal class SntAcceptanceGoodsInfoValidator : AbstractValidator<SntAcceptanceGoodsInfo>
    {
        public SntAcceptanceGoodsInfoValidator()
        {
            RuleFor(x => x.sntId).GreaterThan(0L);

            RuleFor(x => x.acceptanceOrRejectionProducer).NotEmpty();

            RuleFor(x => x.acceptanceOrRejectionDate).NotEmpty();

            RuleFor(x => x.acceptanceOrRejectionName).NotEmpty();
        }
    }
}
