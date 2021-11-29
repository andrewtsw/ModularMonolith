using FluentValidation;
using TCO.SNT.Vstore.Interfaces.UForm;

namespace TCO.SNT.UseCases.UForms.Commands.ImportUForms
{
    internal class UFormParticipantValidator : AbstractValidator<AbstractUFormParticipant>
    {
        public UFormParticipantValidator()
        {
            RuleFor(x => x.address).NotEmpty();

            RuleFor(x => x.name).NotEmpty();

            RuleFor(x => x.storeId).GreaterThan(0L);
            RuleFor(x => x.storeIdSpecified).Equal(true);

            RuleFor(x => x.storeName).NotEmpty();
         
            RuleFor(x => x.tin).NotEmpty();
        }
    }
}
