namespace AuthApi.DependencyInjections
{
    public static class PersistenceInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            //Database Injection
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<AuthDbContext>(options => {options.UseSqlServer(connectionString);});

            //Repository Injection

            return services;
        }
    }
}