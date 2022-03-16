namespace AuthApi.Apis
{
    public class AddressApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/addresses", async (IGenericRepository<Address> repo) =>
                await repo.GetAllAsync())
                .WithTags("Getters");

            app.MapGet("/addresses/{id}", async (Guid id, IGenericRepository<Address> repo) => {
                var entity = await repo.GetAsync(id);
                return Results.Ok(entity);})
                .WithTags("Getters");

            app.MapPost("/addresses", async ([FromBody] Address entity, IGenericRepository<Address> repo) => {
                await repo.InsertAsync(entity);
                return Results.Created($"/addresses/{entity.Id}", entity);})
                .WithTags("Creators");

            app.MapPut("/addresses", async ([FromBody] Address entity, IGenericRepository<Address> repo) => {
                await repo.UpdateAsync(entity);
                return Results.Accepted();})
                .WithTags("Updaters");

            app.MapDelete("/addresses/{id}", async (Guid id, IGenericRepository<Address> repo) => {
                await repo.DeleteAsync(await repo.GetAsync(id));
                return Results.NoContent();})
                .WithTags("Deletors");
        }
    }
}