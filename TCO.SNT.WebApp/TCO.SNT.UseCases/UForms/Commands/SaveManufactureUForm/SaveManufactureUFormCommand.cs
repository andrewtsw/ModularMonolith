using MediatR;

namespace TCO.SNT.UseCases.UForms.Commands.SaveManufactureUForm
{
    public class SaveManufactureUFormCommand : IRequest<int>
    {
        public SaveManufactureUFormCommand(ManufactureUFormDto form)
        {
            Form = form;
        }

        public ManufactureUFormDto Form { get; }
    }
}
