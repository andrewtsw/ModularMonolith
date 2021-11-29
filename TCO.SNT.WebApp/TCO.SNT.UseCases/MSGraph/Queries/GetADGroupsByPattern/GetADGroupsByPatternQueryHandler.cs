using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TCO.Finportal.Infrastructure.MsGraph.Interfaces;

namespace TCO.SNT.UseCases.MSGraph.Queries.GetADGroupsByPattern
{
    internal class GetADGroupsByPatternQueryHandler : IRequestHandler<GetADGroupsByPatternQuery, IReadOnlyList<AdGroupDto>>
    {
        private readonly IMsGraphService _msGraphUniversalService;

        public GetADGroupsByPatternQueryHandler(IMsGraphService msGraphUniversalService)
        {
            _msGraphUniversalService = msGraphUniversalService;
        }

        public async Task<IReadOnlyList<AdGroupDto>> Handle(GetADGroupsByPatternQuery request, CancellationToken cancellationToken)
        {
            return await _msGraphUniversalService.SearchAdGroupsByPatternAsync(request.Seek, cancellationToken);
        }
    }
}
