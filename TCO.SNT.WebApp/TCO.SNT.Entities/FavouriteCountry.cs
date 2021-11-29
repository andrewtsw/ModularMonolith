using System;
using System.Collections.Generic;
using System.Text;

namespace TCO.SNT.Entities
{
    public class FavouriteCountry
    {

        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int SortOrder { get; set; }
    }
}
