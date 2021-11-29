using FluentValidation;
using TCO.SNT.Common.Extensions;
using VsSdk.UForm;

namespace TCO.SNT.UseCases.UForms.Commands.ImportUForms
{
    internal class UFormInfoValidator : AbstractValidator<UFormInfo>
    {
        public UFormInfoValidator()
        {
            RuleFor(x => x.uFormBody).NotEmpty();

            RuleFor(x => x.uFormId).GreaterThan(0L);
            RuleFor(x => x.uFormIdSpecified).Equal(true);

            RuleFor(x => x.inputDate).GreaterThan(Entities.Settings.MinDate);
            RuleFor(x => x.inputDateSpecified).Equal(true);

            RuleFor(x => x.lastUpdateDate).GreaterThan(Entities.Settings.MinDate);
            RuleFor(x => x.lastUpdateDateSpecified).Equal(true);

            RuleFor(x => x.statusSpecified).Equal(true);

            // We can not import drafts from the ESF
            RuleFor(x => x.status).NotEqual(UFormStatusType.DRAFT);

            RuleFor(x => x.cancelReason)
                .NotEmpty()
                .When(x => x.status.In(UFormStatusType.CANCELED, UFormStatusType.FAILED));

            RuleFor(x => x.version).Equal(Entities.UForm.UFormV1);

            RuleFor(x => x.signature).NotEmpty();

            RuleFor(x => x.registrationNumber)
                .Empty()
                .When(x => x.status.In(UFormStatusType.CREATED, UFormStatusType.FAILED));

            RuleFor(x => x.registrationNumber)
                .NotEmpty()
                .When(x => x.status.NotIn(UFormStatusType.CREATED, UFormStatusType.FAILED));

            RuleFor(x => x.creatorLogin).NotEmpty();
        }
    }
}
