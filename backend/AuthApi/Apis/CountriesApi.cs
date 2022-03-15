namespace AuthApi.Apis
{
    public class CountriesApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/countries", async (IGenericRepository<Country> repo) =>
                await repo.GetAllAsync());

            app.MapGet("/countries/{id}", async (Guid id, IGenericRepository<Country> repo) => {
                var entity = await repo.GetAsync(id);
                return Results.Ok(entity);
                });

            app.MapPost("/countries", async ([FromBody] Country country, IGenericRepository<Country> repo) => {
                await repo.InsertAsync(country);
                return Results.Created($"/countries/{country.Id}", country);
                });
        }

    }
}