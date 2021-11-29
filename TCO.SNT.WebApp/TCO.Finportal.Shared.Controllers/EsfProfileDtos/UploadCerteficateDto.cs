using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TCO.Finportal.Shared.Controllers.EsfProfileDtos
{
    public class UploadCerteficateDto
    {
        [Required]
        public string Password { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }
}
