namespace AuthApi.DependencyInjections
{
    public static class ApplicationInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Add AutoMapper Profile
            services.AddAutoMapper(config => { config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));});

            return services;
        }
    }
}