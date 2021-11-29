using System.ComponentModel.DataAnnotations;

namespace TCO.SNT.Entities
{
    public class Currency
    {
        [MaxLength(3)]
        public string Code { get; set; }

        public decimal? Rate { get; set; }
    }
}
