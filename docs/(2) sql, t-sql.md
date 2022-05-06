# Создание реляционных БД  
## Выбор баз данных  
По заданию нам нужно выбрать две базы реляционных базы данных, разделим проект на две части, авторизация и бизнес логика, а соединим их путём user id, который будем передавать через jwt.  
Наш выбор таков:  
* SQL Server (T-SQL)  
* PostgreSQL (SQL)  
## Создание баз данных  
Создавать базы данных будем средствами Entity Framework Core 6.0, установим NuGet пакеты:  
![image.png](https://sun9-13.userapi.com/s/v1/ig2/zONGoqpVE0XrlrRYY1ir9Xv1Rk14SQe2VP1P_ErmbeIUoJldzANjRZuIeQcJSXrMTbz0vKJ6K9nUKwx3hJbjdxly.jpg?size=442x91&quality=96&type=album)  
## Создание контекста базы данных:  
Auth API:  
```cs
public class AuthDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Email> Emails => Set<Email>();
    public DbSet<Country> Countries => Set<Country>();
    public DbSet<City> Cities => Set<City>();
    public DbSet<Address> Addresses => Set<Address>();

    public AuthDbContext(DbContextOptions<AuthDbContext> options) 
        : base(options) { }
}
```  
Внедрим зависимость базы данных:  
```cs
var connectionString = configuration["DbConnection"];
services.AddDbContext<AuthDbContext>(options => 
    {options.UseSqlServer(connectionString);});
```  
Business API:  
```cs
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
```  
Создание конфигураций:  
```cs
public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.HasIndex(e => e.Name).IsUnique();
        builder.HasIndex(e => e.Bio).IsUnique();
        builder.Property(e => e.Bio).HasMaxLength(255);
    }
}
```  
Внедрение зависимости:  
```cs
var connectionString = configuration["DbConnection"];
services.AddDbContext<ShopDbContext>(options => 
    {options.UseNpgsql(connectionString);});
```