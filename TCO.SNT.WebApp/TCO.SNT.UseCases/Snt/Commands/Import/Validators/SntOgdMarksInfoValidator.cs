using EsfApiSdk.Snt;
using FluentValidation;
using System;

namespace TCO.SNT.UseCases.Snt.Commands.Import.Validators
{
    internal class SntOgdMarksInfoValidator : AbstractValidator<SntOgdMarksInfo>
    {
        public SntOgdMarksInfoValidator()
        {
            RuleFor(x => x.sntId).GreaterThan(0L);

            RuleFor(x => x.signDate)
                .GreaterThan(SntInfoValidator.MinInputDate)
                .Must(x => x.Kind == DateTimeKind.Local);

            RuleFor(x => x.sntOgdMarksBody).NotEmpty();

            RuleFor(x => x.sntOgdMarksInfoSignature).NotEmpty();

            RuleFor(x => x.sntOgdMarksInfoCertificate).NotEmpty();

            RuleFor(x => x.ogdEmployeeFullName).NotEmpty();
        }
    }
}
