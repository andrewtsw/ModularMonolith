using System.Collections.Generic;

namespace TCO.SNT.UseCases.GroupTaxpayerStores.Queries.GetAllGroupTaxpayerStores
{
    public class GroupTaxpayerStoresDto
    {
        public GroupDescriptionDto Group { get; set; }

        public IReadOnlyList<TaxpayerStoreDescriptionDto> TaxpayerStores { get; set; }
    }
}
