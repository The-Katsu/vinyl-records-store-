namespace AuthApi.DependencyInjections
{
    public static class PersistenceInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //Database Injection
            var connectionString = configuration["DbConnection1"];
            services.AddDbContext<AuthDbContext>(options => {options.UseSqlServer(connectionString);});

            return services;
        }
    }
}