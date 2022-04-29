using Domain.Shop;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Shop.EntityTypeConfiguration;

public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.HasIndex(e => e.Name).IsUnique();
        builder.HasIndex(e => e.Bio).IsUnique();
        builder.Property(e => e.Bio).HasMaxLength(255);
    }
}