namespace AuthApi.Apis
{
    public class CitiesApi
    {
        public async void Register(WebApplication app)
        {
            app.MapGet("/cities", [Authorize(Roles="Admin, Moderator")] async (IGenericRepository<City> repo, IMapper mapper) =>
                mapper.Map<List<CityVm>>(await repo.GetAllAsync()))
                .WithTags("Getters");

            app.MapGet("/cities/{id}", [Authorize(Roles="Admin, Moderator")] async (Guid id, IGenericRepository<City> repo, IMapper mapper) => 
                mapper.Map<CityVm>(await repo.GetAsync(id)))
                .WithTags("Getters");

            app.MapPost("/cities", [Authorize(Roles="Admin, Moderator")] async ([FromBody] CreateCityDto entity, IGenericRepository<City> repo, IMapper mapper) => {
                await repo.InsertAsync(mapper.Map<City>(entity));
                return Results.Ok();})
                .WithTags("Creators");

            app.MapPut("/cities", [Authorize(Roles="Admin, Moderator")] async ([FromBody] UpdateCityDto entity, IGenericRepository<City> repo, IMapper mapper) => {
                await repo.UpdateAsync(mapper.Map<City>(entity));
                return Results.Accepted();})
                .WithTags("Updaters");

            app.MapDelete("/cities/{id}", [Authorize(Roles="Admin, Moderator")] async (Guid id, IGenericRepository<City> repo) => {
                await repo.DeleteAsync(await repo.GetAsync(id));
                return Results.NoContent();})
                .WithTags("Deletors");
        }
    }
}