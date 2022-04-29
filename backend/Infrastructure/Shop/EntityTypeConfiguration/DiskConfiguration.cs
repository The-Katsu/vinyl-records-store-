using Domain.Shop;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Shop.EntityTypeConfiguration;

public class DiskConfiguration : IEntityTypeConfiguration<Disk>
{
    public void Configure(EntityTypeBuilder<Disk> builder)
    {
        builder.HasIndex(e => e.Name).IsUnique();
        builder.Property(e => e.About).HasMaxLength(255);
    }
}