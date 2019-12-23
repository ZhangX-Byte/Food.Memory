using FoodMemory.SharedKernel.Aggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FoodMemory.EventEFRepository.EntitiesConfig
{
    public sealed class MetadataContainersConfig: IEntityTypeConfiguration<MetadataContainer>
    {
        public void Configure(EntityTypeBuilder<MetadataContainer> builder)
        {
            builder.HasKey(q => q.EventId);
            builder.Property(q => q.AggregateId).IsRequired();
            builder.Property(q => q.AggregateName).IsRequired().HasMaxLength(500);
            builder.Property(q => q.AggregateVersion).IsRequired();
            builder.Property(q => q.CreatedTime).IsRequired();
            builder.Property(q => q.Data).IsRequired();
            builder.Property(q => q.EventName).IsRequired().HasMaxLength(500);
            builder.Property(q => q.EventVersion).IsRequired();
        }
    }
}
