using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TCO.SNT.Entities
{
    public class FavouriteCurrency
    {
        [MaxLength(3)]
        public string CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public int SortOrder { get; set; }
    }
}
