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
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IEmailRepository, EmailRepository>();

            return services;
        }
    }
}