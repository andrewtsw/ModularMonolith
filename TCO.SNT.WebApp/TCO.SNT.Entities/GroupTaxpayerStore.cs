using System;
using TCO.Finportal.Framework.Domain.Entities;

namespace TCO.SNT.Entities
{
    public class GroupTaxpayerStore : AuditableEntity
    {
        public Guid GroupId { get; set; }

        public int TaxpayerStoreId { get; set; }

        public TaxpayerStore TaxpayerStore { get; set; }
    }
}