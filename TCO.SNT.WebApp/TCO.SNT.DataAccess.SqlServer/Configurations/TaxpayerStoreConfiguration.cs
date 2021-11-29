using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;
using TCO.SNT.Entities;
using Newtonsoft.Json;

namespace TCO.SNT.DataAccess.SqlServer.Configurations
{
    public class TaxpayerStoreConfiguration : IEntityTypeConfiguration<TaxpayerStore>
    {
        public void Configure(EntityTypeBuilder<TaxpayerStore> builder)
        {
            builder
                .HasIndex(x => x.ExternalId)
                .IsUnique();

            // TODO: EF generates update for PermittedTinList on each save. 
            // Need to investigate i and update only when PermittedTinList had been changed. 

            var permittedTinListComparer = new ValueComparer<string[]>(
               (c1, c2) => c1.SequenceEqual(c2),
               c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
               c => c.ToArray());

            builder
                .Property(x => x.PermittedTinList)
                .HasConversion(
                    v => v != null && v.Length > 0 ? JsonConvert.SerializeObject(v) : null,
                    v => !string.IsNullOrEmpty(v) ? JsonConvert.DeserializeObject<string[]>(v) : new string[0])
                .Metadata
                .SetValueComparer(permittedTinListComparer);
        }
    }
}
