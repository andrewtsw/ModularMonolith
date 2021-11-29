using MediatR;

namespace TCO.SNT.UseCases.Balances.Queries.GetBalanceReport
{
    public class GetBalanceReportQuery : IRequest<BalanceListReportResponseDto>
    {

        public GetBalanceReportQuery(BalanceListReportRequestDto dto, string basePath)
        {
            Dto = dto;
            BasePath = basePath;
        }

        public BalanceListReportRequestDto Dto;

        public string BasePath;
    }
}
