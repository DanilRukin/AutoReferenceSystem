using AutoReferenceSystem.ApplicationServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AutoReferenceSystem.ApplicationServer.Data.Configurations
{
    internal class ReferencingQueryCharacteristicEntityTypeConfiguration : IEntityTypeConfiguration<ReferencingQueryCharacteristic>
    {
        public void Configure(EntityTypeBuilder<ReferencingQueryCharacteristic> builder)
        {
            builder.HasKey(r => new { r.CharacteristicId, r.ReferensingQueryId });
        }
    }
}
