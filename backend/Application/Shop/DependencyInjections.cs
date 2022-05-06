using Application.Shop.Interfaces;
using Application.Shop.Repositories;

namespace Application.Shop;

public static class DependencyInjections
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        //Add services
        services.AddScoped(typeof(Interfaces.IGenericRepository<>), typeof(Repositories.GenericRepository<>));
        services.AddScoped<IBillRepository, BillRepository>();
        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddScoped<IDiskRepository, DiskRepository>();
        services.AddScoped<IBasketRepository, BasketRepository>();
        
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
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            }); 
        
        return services;
    }
}