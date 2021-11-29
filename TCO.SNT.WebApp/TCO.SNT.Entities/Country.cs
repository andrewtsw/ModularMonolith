using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TCO.SNT.Entities
{
    public class Country
    {
        public int Id { get; set; }
        [MaxLength(254)]
        public string NameRu { get; set; }
        [MaxLength(2)]
        public string Alpha2 { get; set; }
        [MaxLength(3)]
        public string Alpha3 { get; set; }

    }
}
