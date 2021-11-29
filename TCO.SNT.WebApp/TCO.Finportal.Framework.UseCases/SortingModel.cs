using System.ComponentModel.DataAnnotations;

namespace TCO.Finportal.Framework.UseCases
{
    public class SortingModel
    {
        [Required]
        public string SortColumn { get; set; }

        public SortingOrder SortOrder { get; set; }

        public SortingModel()
        {
            SortOrder = SortingOrder.Desc;
        }
    }
}
