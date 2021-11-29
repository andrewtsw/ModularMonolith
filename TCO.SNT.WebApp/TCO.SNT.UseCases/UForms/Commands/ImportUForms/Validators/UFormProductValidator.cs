using FluentValidation;
using TCO.SNT.Vstore.Interfaces.UForm;

namespace TCO.SNT.UseCases.UForms.Commands.ImportUForms
{
    internal class UFormProductValidator : AbstractValidator<UFormProduct>
    {
        public UFormProductValidator()
        {
            // AbstractUFormProduct fields
            RuleFor(x => x.gsvsCode).NotEmpty();

            RuleFor(x => x.measureUnitCode).NotEmpty();

            RuleFor(x => x.price)
                .GreaterThan(0m)
                .When(x => x.priceSpecified);

            RuleFor(x => x.quantity).GreaterThan(0m);

            RuleFor(x => x.sum)
                .GreaterThan(0m)
                .When(x => x.sumSpecified);

            // UFormProduct fields
            RuleFor(x => x.name).NotEmpty();

            RuleFor(x => x.productId)
                .GreaterThan(0L)
                .When(x => x.productIdSpecified);

            RuleFor(x => x.spiritPercent)
                .GreaterThan(0m)
                .When(x => x.spiritPercentSpecified);

            RuleFor(x => x.tnvedCode).NotEmpty();
        }
    }
}
