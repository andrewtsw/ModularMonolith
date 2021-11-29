using MediatR;

namespace TCO.SNT.UseCases.Snt.Queries.GetSntList
{
    public class GetSntListQuery : IRequest<SntListResponseDto>
    {
        public GetSntListQuery(SntListRequestDto dto)
        {
            Dto = dto;
        }

        public SntListRequestDto Dto { get; }
    }
}
