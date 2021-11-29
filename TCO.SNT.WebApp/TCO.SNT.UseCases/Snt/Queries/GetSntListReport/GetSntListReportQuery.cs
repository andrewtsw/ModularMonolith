using MediatR;
using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.UseCases.Snt.Queries.GetSntListReport
{
    public class GetSntListReportQuery : IRequest<SntListReportResponseDto>
    {
        public GetSntListReportQuery(SntListFilter filter, string basePath)
        {
            Filter = filter;
            BasePath = basePath;
        }

        public SntListFilter Filter { get; }

        public string BasePath { get; }
    }
}
