using MediatR;

namespace TCO.EInvoicing.UseCases.Awp.Queries.GetAwpList
{
    public class GetAwpListQuery : IRequest<AwpListResponseDto>
    {
        public GetAwpListQuery(AwpListRequestDto dto)
        {
            Dto = dto;
        }

        public AwpListRequestDto Dto { get; }
    }
}
