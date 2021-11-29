using MediatR;

namespace TCO.SNT.UseCases.Snt.Queries.GetSntFull
{
    public class GetSntFullQuery : IRequest<SntFullDto>
    {
        public GetSntFullQuery(int sntId)
        {
            SntId = sntId;
        }

        public int SntId { get; }
    }
}
