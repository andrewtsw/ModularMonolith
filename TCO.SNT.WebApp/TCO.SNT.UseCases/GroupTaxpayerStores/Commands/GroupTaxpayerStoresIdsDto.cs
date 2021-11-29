using System;
using System.ComponentModel.DataAnnotations;

namespace TCO.SNT.UseCases.GroupTaxpayerStores.Commands
{
    public class GroupTaxpayerStoresIdsDto
    {
        public Guid GroupId { get; set; }

        [Required, MinLength(1)]
        public int[] TaxpayerStoreIds { get; set; }
    }
}