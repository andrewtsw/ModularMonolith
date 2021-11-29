using MediatR;

namespace TCO.SNT.UseCases.UForms.Commands.SaveMovementUForm
{
    public class SaveMovementUFormCommand : IRequest<int>
    {
        public SaveMovementUFormCommand(MovementUFormDto form)
        {
            Form = form;
        }

        public MovementUFormDto Form { get; }
    }
}
