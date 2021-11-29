using System.Collections.Generic;
using TCO.Finportal.Framework.UseCases;

namespace TCO.SNT.UseCases.UForms.Queries.GetAllUForms
{
    public class UFormListResponseDto
    {
        public IReadOnlyList<UFormSimpleDto> Uforms { get; set; }

        public PagingModel Paging { get; set; }
    }
}
