using EsfApiSdk.Snt;
using FluentValidation;
using System;

namespace TCO.SNT.UseCases.Snt.Commands.Import.Validators
{
    internal class SntDocumentInfoValidator : AbstractValidator<SntDocumentInfo>
    {
        public SntDocumentInfoValidator()
        {
            RuleFor(x => x.sntId).GreaterThan(0L);

            RuleFor(x => x.inputDate)
                .GreaterThan(SntInfoValidator.MinInputDate)
                .Must(x => x.Kind == DateTimeKind.Local);

            RuleFor(x => x.sntBody).NotEmpty();

            RuleFor(x => x.creatorLogin).NotEmpty();

            RuleFor(x => x.creatorTin).NotEmpty();

            RuleFor(x => x.creatorProjectCode)
                .GreaterThan(0L)
                .When(x => x.creatorProjectCodeSpecified);

            RuleFor(x => x.senderSignerName).NotEmpty();

            RuleFor(x => x.signature).NotEmpty();

            RuleFor(x => x.certificate).NotEmpty();
        }
    }
}
