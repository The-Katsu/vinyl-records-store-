namespace AuthApi.DependencyInjections
{
    public static class ApplicationInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Add AutoMapper Profile
            services.AddAutoMapper(config => { config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));});

            //Add token service
            services.AddSingleton<ITokenService>(new TokenService());

            //Add bearer auth
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Jwt");
            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = config["Issuer"],
                        ValidAudience = config["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(config["Key"]))
                    };
                }); 

            

            return services;
        }
    }
}