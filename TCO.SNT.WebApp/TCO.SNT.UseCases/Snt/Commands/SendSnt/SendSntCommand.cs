using MediatR;

namespace TCO.SNT.UseCases.Snt.Commands.SendSnt
{
    public class SendSntCommand : IRequest
    {
        public SendSntCommand(SendSntDto dto)
        {
            Dto = dto;
        }

        public SendSntDto Dto { get; }
    }
}
