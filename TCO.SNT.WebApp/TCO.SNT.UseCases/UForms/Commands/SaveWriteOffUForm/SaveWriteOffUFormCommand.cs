using MediatR;

namespace TCO.SNT.UseCases.UForms.Commands.SaveWriteOffUForm
{
    public class SaveWriteOffUFormCommand : IRequest<int>
    {
        public SaveWriteOffUFormCommand(WriteOffUFormDto form)
        {
            Form = form;
        }

        public WriteOffUFormDto Form { get; }
    }
}
