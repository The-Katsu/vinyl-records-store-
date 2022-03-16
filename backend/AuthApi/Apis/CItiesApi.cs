namespace AuthApi.Apis
{
    public class CitiesApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/cities", async (IGenericRepository<City> repo) =>
                await repo.GetAllAsync())
                .WithTags("Getters");

            app.MapGet("/cities/{id}", async (Guid id, IGenericRepository<City> repo) => {
                var entity = await repo.GetAsync(id);
                return Results.Ok(entity);})
                .WithTags("Getters");

            app.MapPost("/cities", async ([FromBody] City entity, IGenericRepository<City> repo) => {
                await repo.InsertAsync(entity);
                return Results.Created($"/cities/{entity.Id}", entity);})
                .WithTags("Creators");

            app.MapPut("/cities", async ([FromBody] City entity, IGenericRepository<City> repo) => {
                await repo.UpdateAsync(entity);
                return Results.Accepted();})
                .WithTags("Updaters");

            app.MapDelete("/cities/{id}", async (Guid id, IGenericRepository<City> repo) => {
                await repo.DeleteAsync(await repo.GetAsync(id));
                return Results.NoContent();})
                .WithTags("Deletors");
        }
    }
}