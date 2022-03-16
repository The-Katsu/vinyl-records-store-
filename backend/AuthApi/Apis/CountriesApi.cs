namespace AuthApi.Apis
{
    public class CountriesApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/countries", async (IGenericRepository<Country> repo) =>
                await repo.GetAllAsync())
                .WithTags("Getters");

            app.MapGet("/countries/{id}", async (Guid id, IGenericRepository<Country> repo) => {
                var entity = await repo.GetAsync(id);})
                .WithTags("Getters");

            app.MapPost("/countries", async ([FromBody] Country entity, IGenericRepository<Country> repo) => {
                await repo.InsertAsync(entity);
                return Results.Created($"/countries/{entity.Id}", entity);})
                .WithTags("Creators");

            app.MapPut("/countries", async ([FromBody] Country entity, IGenericRepository<Country> repo) => {
                await repo.UpdateAsync(entity);
                return Results.Accepted();})
                .WithTags("Updaters");

            app.MapDelete("/countries/{id}", async (Guid id, IGenericRepository<Country> repo) => {
                await repo.DeleteAsync(await repo.GetAsync(id));
                return Results.NoContent();})
                .WithTags("Deletors");
        }
    }
}