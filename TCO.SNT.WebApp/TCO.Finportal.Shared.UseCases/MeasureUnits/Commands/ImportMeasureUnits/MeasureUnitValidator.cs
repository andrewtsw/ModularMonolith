using FluentValidation;
using System;
using VsSdk.Dictionaries;

namespace TCO.Finportal.Shared.UseCases.MeasureUnits.Commands.ImportMeasureUnits
{
    internal class MeasureUnitValidator :  AbstractValidator<MeasureUnit>
    {
        private static readonly int CodeMaxLength = 16;

        private static readonly int NameMaxLength = 400;

        private static readonly DateTime MinLastUpdateDate = new DateTime(2017, 1, 1);

        public MeasureUnitValidator()
        {
            RuleFor(x => x.code).NotEmpty().MaximumLength(CodeMaxLength);

            RuleFor(x => x.codeMkei).MaximumLength(CodeMaxLength);

            RuleFor(x => x.codeOkei).MaximumLength(CodeMaxLength);

            RuleFor(x => x.codeTis).MaximumLength(CodeMaxLength);

            RuleFor(x => x.lastUpdateDate)
                .GreaterThan(MinLastUpdateDate)
                .Must(x => x.Kind == DateTimeKind.Local);
            RuleFor(x => x.lastUpdateDateSpecified).Equal(true);


            RuleFor(x => x.nameKz).NotEmpty().MaximumLength(NameMaxLength);

            RuleFor(x => x.nameRu).NotEmpty().MaximumLength(NameMaxLength);
        }
    }
}
