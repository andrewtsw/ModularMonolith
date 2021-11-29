using MediatR;
using System.Collections.Generic;
using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.UseCases.Snt.Queries.SearchSntParticipantsByName
{
    public class SearchSntParticipantsByNameQuery : IRequest<IReadOnlyList<SntParticipantShortDto>>
    {
        public SearchSntParticipantsByNameQuery(string name, int limit)
        {
            Name = name;
            Limit = limit;
        }

        public string Name { get; }

        public int Limit { get; }
    }
}
