using MediatR;

namespace TCO.SNT.UseCases.UForms.Queries.GetUFormFull
{
    public class GetUFormFullQuery : IRequest<UFormFullDto>
    {
        public GetUFormFullQuery(int uFormId)
        {
            UFormId = uFormId;
        }

        public int UFormId { get; }
    }
}
