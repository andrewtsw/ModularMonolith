using FluentValidation;
using System;
using System.Globalization;
using TCO.SNT.Vstore.Interfaces.UForm;

namespace TCO.SNT.UseCases.UForms.Commands.ImportUForms
{
    internal class UFormValidator : AbstractValidator<UForm>
    {
        public UFormValidator()
        {
            // AbstractUForm fields
            var minDate = new DateTime(2019, 1, 1);
            RuleFor(x => x.date)
                .NotEmpty()
                .Must(date => {
                    var parsed = DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    return parsed > minDate;
                });
            RuleFor(x => x.number).NotEmpty();

            RuleFor(x => x.sender)
                .NotNull()
                .SetValidator(new UFormParticipantValidator());

            RuleFor(x => x.recipient)
                .SetValidator(new UFormParticipantValidator())
                .When(x => x.recipient != null);

            RuleFor(x => x.totalSum).GreaterThan(0m);
            RuleFor(x => x.totalSumSpecified).Equal(true);

            // UForm fields
            RuleFor(x => x.products).NotEmpty();
            RuleForEach(x => x.products).SetValidator(new UFormProductValidator());

            RuleFor(x => x.reorganizationTypeSpecified)
                .Equal(true)
                .When(x => x.type == euFormType.REORGANIZATION);

            // TODO: rules for SourceProducts and SourceTotalSum

            RuleFor(x => x.writeOffReasonSpecified)
                .Equal(true)
                .When(x => x.type == euFormType.WRITE_OFF);
        }
    }
}
