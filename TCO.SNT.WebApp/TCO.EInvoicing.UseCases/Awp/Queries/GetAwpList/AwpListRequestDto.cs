using System.ComponentModel.DataAnnotations;
using TCO.EInvoicing.UseCases.Awp.Shared;
using TCO.Finportal.Framework.UseCases;

namespace TCO.EInvoicing.UseCases.Awp.Queries.GetAwpList
{
    public class AwpListRequestDto
    {
        public AwpListFilter Filter { get; set; }

        public SortingModel Sorting { get; set; }

        [Required]
        public RequestPagingModel Paging { get; set; }
    }

}
