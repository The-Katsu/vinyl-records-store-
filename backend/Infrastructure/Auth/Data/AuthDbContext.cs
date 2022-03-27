namespace AuthApi.Data
{
    public class AuthDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Email> Emails => Set<Email>();
        public DbSet<Country> Countries => Set<Country>();
        public DbSet<City> Cities => Set<City>();
        public DbSet<Address> Addresses => Set<Address>();

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}