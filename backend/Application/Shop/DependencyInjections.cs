namespace Application.Shop;

public static class DependencyInjections
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //Add services
        services.AddScoped(typeof(Interfaces.IGenericRepository<>), typeof(Repositories.GenericRepository<>));

        return services;
    }
}