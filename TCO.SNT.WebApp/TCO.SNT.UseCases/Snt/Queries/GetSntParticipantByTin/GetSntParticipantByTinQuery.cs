using MediatR;
using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.UseCases.Snt.Queries.GetSntParticipantByTin
{
    public class GetSntParticipantByTinQuery : IRequest<SntParticipantDto>
    {
        public GetSntParticipantByTinQuery(string tin)
        {
            Tin = tin;
        }

        public string Tin { get; }
    }
}
