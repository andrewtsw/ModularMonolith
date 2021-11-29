using EsfApiSdk.Snt;
using FluentValidation;
using System;

namespace TCO.SNT.UseCases.Snt.Commands.Import.Validators
{
    internal class SntInfoValidator : AbstractValidator<SntInfo>
    {
        public static readonly DateTime MinInputDate = new DateTime(2020, 1, 1);

        public SntInfoValidator()
        {
            RuleFor(x => x.sntId).GreaterThan(0L);

            RuleFor(x => x.inputDate)
                .GreaterThan(MinInputDate)
                .Must(x => x.Kind == DateTimeKind.Local);

            RuleFor(x => x.lastUpdateDate)
                .GreaterThan(MinInputDate)
                .Must(x => x.Kind == DateTimeKind.Local);

            RuleFor(x => x.documentInfo)
                .NotEmpty()
                .SetValidator(new SntDocumentInfoValidator());

            RuleFor(x => x.acceptanceGoodsInfo)
                .SetValidator(new SntAcceptanceGoodsInfoValidator())
                .When(x => x.acceptanceGoodsInfo != null);

            RuleFor(x => x.ogdMarksInfo)
                .SetValidator(new SntOgdMarksInfoValidator())
                .When(x => x.ogdMarksInfo != null);
        }
    }
}
