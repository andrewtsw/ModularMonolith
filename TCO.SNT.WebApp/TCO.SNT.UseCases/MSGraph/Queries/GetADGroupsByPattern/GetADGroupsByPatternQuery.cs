using MediatR;
using System.Collections.Generic;
using TCO.Finportal.Infrastructure.MsGraph.Interfaces;

namespace TCO.SNT.UseCases.MSGraph.Queries.GetADGroupsByPattern
{
    public class GetADGroupsByPatternQuery : IRequest<IReadOnlyList<AdGroupDto>>
    {
        public GetADGroupsByPatternQuery(string seek)
        {
            Seek = seek;
        }

        public string Seek { get; }
    }
}
