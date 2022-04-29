using Domain.Shop;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Shop.EntityTypeConfiguration;

public class GenreConfiguration : IEntityTypeConfiguration<Genre>
{
    public void Configure(EntityTypeBuilder<Genre> builder)
    {
        builder.HasIndex(e => e.Name).IsUnique();
    }
}