using MediatR;

namespace TCO.SNT.UseCases.UForms.Queries.GetUFormListReport
{
    public class GetUFormListReportQuery : IRequest<UFormListReportResponseDto>
    {
        public GetUFormListReportQuery(UFormListReportRequestDto dto, string basePath)
        {
            Dto = dto;
            BasePath = basePath;
        }

        public UFormListReportRequestDto Dto { get; }

        public string BasePath { get; }
    }
}