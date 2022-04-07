namespace AuthApi.Apis
{
    public class CountriesApi
    {
        public async void Register(WebApplication app)
        {
            app.MapGet("/countries", [Authorize(Roles="Admin, Moderator")] async (IGenericRepository<Country> repo, IMapper mapper) => 
                mapper.Map<List<CountryVm>>(await repo.GetAllAsync()))
                .WithTags("Getters");

            app.MapGet("/countries/{id}", [Authorize(Roles="Admin, Moderator")] async (Guid id, IGenericRepository<Country> repo, IMapper mapper) => 
                mapper.Map<CountryVm>(await repo.GetAsync(id)))
                .WithTags("Getters");

            app.MapPost("/countries", [Authorize(Roles="Admin, Moderator")] async ([FromBody] CreateCountryDto entity, IGenericRepository<Country> repo, IMapper mapper) => {
                await repo.InsertAsync(mapper.Map<Country>(entity));
                return Results.Ok();})
                .WithTags("Creators");

            app.MapPut("/countries", [Authorize(Roles="Admin, Moderator")] async ([FromBody] UpdateCountryDto entity, IGenericRepository<Country> repo, IMapper mapper) => {
                await repo.UpdateAsync(mapper.Map<Country>(entity));
                return Results.Accepted();})
                .WithTags("Updaters");

            app.MapDelete("/countries/{id}", [Authorize(Roles="Admin, Moderator")] async (Guid id, IGenericRepository<Country> repo) => {
                await repo.DeleteAsync(await repo.GetAsync(id));
                return Results.NoContent();})
                .WithTags("Deletors");
        }
    }
}