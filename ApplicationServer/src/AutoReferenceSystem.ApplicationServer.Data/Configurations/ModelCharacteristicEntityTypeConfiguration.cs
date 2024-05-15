using AutoReferenceSystem.ApplicationServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace AutoReferenceSystem.ApplicationServer.Data.Configurations
{
    internal class ModelCharacteristicEntityTypeConfiguration : IEntityTypeConfiguration<ModelCharacteristic>
    {
        public void Configure(EntityTypeBuilder<ModelCharacteristic> builder)
        {
            builder.HasKey(m => new { m.ModelId, m.CharacteristicId });
        }
    }
}
