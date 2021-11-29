using MediatR;

namespace TCO.SNT.UseCases.UForms.Commands.SaveBalanceUForm
{
    public class SaveBalanceUFormCommand : IRequest<int>
    {
        public SaveBalanceUFormCommand(BalanceUFormDto form)
        {
            Form = form;
        }

        public BalanceUFormDto Form { get; }
    }
}
