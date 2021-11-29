using MediatR;

namespace TCO.SNT.UseCases.UForms.Commands.SendUForm
{
    public class SendUFormCommand : IRequest
    {
        public SendUFormCommand(int formId)
        {
            FormId = formId;
        }

        public int FormId { get; }
    }
}
