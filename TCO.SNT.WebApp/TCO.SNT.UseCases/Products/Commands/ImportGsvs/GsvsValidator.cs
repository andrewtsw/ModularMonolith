using FluentValidation;
using System;
using VsSdk.Dictionaries;

namespace TCO.SNT.UseCases.Products.Commands.ImportGsvs
{
    internal class GsvsValidator : AbstractValidator<Gsvs>
    {
        private static readonly DateTime MinDate = new DateTime(1999, 1, 1);

        public GsvsValidator()
        {
            RuleFor(x => x.code).NotEmpty();

            //RuleFor(x => x.id).GreaterThanOrEqualTo(0);
            //RuleFor(x => x.idSpecified).Equal(true);

            RuleFor(x => x.fixedId).GreaterThanOrEqualTo(0);
            RuleFor(x => x.fixedIdSpecified).Equal(true);

            //RuleFor(x => x.lastUpdateDate)
            //    .GreaterThanOrEqualTo(MinDate)
            //    .Must(x => x.Kind == DateTimeKind.Local);
            //RuleFor(x => x.lastUpdateDateSpecified).Equal(true);

            //RuleFor(x => x.startDate)
            //    .GreaterThanOrEqualTo(MinDate)
            //    .Must(x => x.Kind == DateTimeKind.Local);

            RuleFor(x => x.endDate)
                .GreaterThanOrEqualTo(MinDate)
                .Must(x => x.Kind == DateTimeKind.Local)
                .When(x => x.endDateSpecified);
            
            //RuleFor(x => x.nameRu).NotEmpty();
        }
    }
}
