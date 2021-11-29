using System.ComponentModel.DataAnnotations;

namespace TCO.Finportal.Infrastructure.MsGraph.Interfaces
{
    public class AdGroupDto
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
