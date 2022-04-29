using Domain.Shop;
using Infrastructure.Shop.EntityTypeConfiguration;

namespace Infrastructure.Shop.Data;

public class ShopDbContext : DbContext
{ 
    public DbSet<Artist> Artist => Set<Artist>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Format> Formats => Set<Format>();
    public DbSet<Disk> Disks => Set<Disk>();
    public DbSet<Bill> Bills => Set<Bill>();
    public DbSet<Basket> Baskets => Set<Basket>();
    
    public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new ArtistConfiguration());
        builder.ApplyConfiguration(new DiskConfiguration());
        builder.ApplyConfiguration(new FormatConfiguration());
        builder.ApplyConfiguration(new GenreConfiguration());
        base.OnModelCreating(builder);
    }
}