using System.Collections.Generic;
using TCO.Finportal.Framework.UseCases;
using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.UseCases.Snt.Queries.GetSntList
{
    public class SntListResponseDto
    {
        public IReadOnlyList<SntSimpleDto> Snts { get; set; }

        public PagingModel Paging { get; set; }
    }
}
