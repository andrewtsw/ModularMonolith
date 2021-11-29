using MediatR;
using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.UseCases.Snt.Commands.SendSntReport
{
    public class SendSntReportCommand : IRequest
    {
        public SendSntReportCommand(SntListFilter filter, string basePath)
        {
            Filter = filter;
            BasePath = basePath;
        }

        public SntListFilter Filter { get; }

        public string BasePath { get; }
    }
}
