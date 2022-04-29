using Domain.Shop;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Shop.EntityTypeConfiguration;

public class FormatConfiguration : IEntityTypeConfiguration<Format>
{
    public void Configure(EntityTypeBuilder<Format> builder)
    {
        builder.HasIndex(e => e.Name).IsUnique();
    }
}