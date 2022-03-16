var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddApplication();
builder.Services.AddPersistence(configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
    //db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
}

new CountriesApi().Register(app);
new CitiesApi().Register(app);

app.MapGet("/", () => "Hello World!");

app.UseHttpsRedirection();

app.Run();