using Infrastructure.Shop.Data;

namespace Infrastructure.Shop;

public static class DependencyInjections
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        //Database Injection
        var connectionString = configuration["DbConnection"];
        services.AddDbContext<ShopDbContext>(options => {options.UseNpgsql(connectionString);});

        return services;
    }
}