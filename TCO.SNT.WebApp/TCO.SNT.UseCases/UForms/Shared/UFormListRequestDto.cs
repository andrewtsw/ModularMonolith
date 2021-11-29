using System.ComponentModel.DataAnnotations;
using TCO.Finportal.Framework.UseCases;
using TCO.SNT.UseCases.UForms.Shared;

namespace TCO.SNT.UseCases.UForms.Queries.Shared
{
    public class UFormListRequestDto
    {
        public UFormFilter Filter { get; set; }

        public SortingModel Sorting { get; set; }

        [Required]
        public RequestPagingModel Paging { get; set; }
    }

}
