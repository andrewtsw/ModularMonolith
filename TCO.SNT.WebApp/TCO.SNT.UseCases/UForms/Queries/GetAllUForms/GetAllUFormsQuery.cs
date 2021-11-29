using MediatR;
using TCO.SNT.UseCases.UForms.Queries.Shared;

namespace TCO.SNT.UseCases.UForms.Queries.GetAllUForms
{
    public class GetAllUFormsQuery : IRequest<UFormListResponseDto>
    {
        public GetAllUFormsQuery(UFormListRequestDto dto)
        {
            Dto = dto;
        }

        public UFormListRequestDto Dto { get; }
    }
}
