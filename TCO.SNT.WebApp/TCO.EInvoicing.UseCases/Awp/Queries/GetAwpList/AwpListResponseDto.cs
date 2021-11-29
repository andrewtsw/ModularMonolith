using System.Collections.Generic;
using TCO.EInvoicing.UseCases.Awp.Models;
using TCO.Finportal.Framework.UseCases;

namespace TCO.EInvoicing.UseCases.Awp.Queries.GetAwpList
{
    public class AwpListResponseDto
    {
        public IReadOnlyList<AwpDto> Awps { get; set; }

        public PagingModel Paging { get; set; }
    }
}
