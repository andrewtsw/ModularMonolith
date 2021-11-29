using System.ComponentModel.DataAnnotations;
using TCO.Finportal.Framework.UseCases;
using TCO.SNT.UseCases.Snt.Shared;

namespace TCO.SNT.UseCases.Snt.Queries.GetSntList
{
    public class SntListRequestDto
    {
        public SntListFilter Filter { get; set; }

        public SortingModel Sorting { get; set; }

        [Required]
        public RequestPagingModel Paging { get; set; }
    }

}
