var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, config) =>
{
    config.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<UsersApi>();

ConfigurationManager configuration = builder.Configuration;

builder.Services.AddAutoMapper(config => { config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));});

builder.Services.AddPersistence(configuration);
builder.Services.AddApplication();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter JWT Bearer token **_only_**",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };
    c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
    //db.Database.EnsureDeleted(); //Delete if changes
    db.Database.EnsureCreated();
    var service = scope.ServiceProvider.GetService<UsersApi>();
    service.Register(app);
}

app.UseCustomExceptionHandler();

new CountriesApi().Register(app);
new CitiesApi().Register(app);
new AddressesApi().Register(app);
new EmailsApi().Register(app);
//new UsersApi().Register(app);

app.UseHttpsRedirection();

app.Run();