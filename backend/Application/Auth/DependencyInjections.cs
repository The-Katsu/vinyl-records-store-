namespace AuthApi.DependencyInjections
{
    public static class ApplicationInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //Add token service
            services.AddSingleton<ITokenService>(new TokenService());

            //Add identity service
            services.AddTransient<IIdentityDetection, IdentityDetection>();

            //Repository Injection
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IEmailRepository, EmailRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

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