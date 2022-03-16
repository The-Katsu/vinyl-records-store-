namespace AuthApi.Apis
{
    public class AddressesApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/addresses", async (IGenericRepository<Address> repo, IMapper mapper) =>
                mapper.Map<List<AddressVm>>(await repo.GetAllAsync()))
                .WithTags("Getters");

            app.MapGet("/addresses/{id}", async (Guid id, IGenericRepository<Address> repo, IMapper mapper) => 
                mapper.Map<AddressVm>(await repo.GetAsync(id)))
                .WithTags("Getters");

            app.MapPost("/addresses", async ([FromBody] CreateAddressDto entity, IGenericRepository<Address> repo, IMapper mapper) => {
                await repo.InsertAsync(mapper.Map<Address>(entity));
                return Results.Ok();})
                .WithTags("Creators");

            app.MapPut("/addresses", async ([FromBody] UpdateAddressDto entity, IGenericRepository<Address> repo, IMapper mapper) => {
                await repo.UpdateAsync(mapper.Map<Address>(entity));
                return Results.Accepted();})
                .WithTags("Updaters");

            app.MapDelete("/addresses/{id}", async (Guid id, IGenericRepository<Address> repo) => {
                await repo.DeleteAsync(await repo.GetAsync(id));
                return Results.NoContent();})
                .WithTags("Deletors");
        }
    }
}