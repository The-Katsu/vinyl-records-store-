namespace AuthApi.Apis
{
    public class AddressesApi
    {
        public void Register(WebApplication app)
        {
            app.MapGet("/addresses", [Authorize] async (IGenericRepository<Address> repo, IMapper mapper) =>
                mapper.Map<List<AddressVm>>(await repo.GetAllAsync()))
                .WithTags("Getters");

            app.MapGet("/addresses/{id}", [Authorize(Roles = "Admin")] async (Guid id, IGenericRepository<Address> repo, IMapper mapper) => 
                mapper.Map<AddressVm>(await repo.GetAsync(id)))
                .WithTags("Getters");

            app.MapPost("/addresses",[Authorize] async ([FromBody] CreateAddressDto entity, IGenericRepository<Address> repo, IMapper mapper, HttpContext context) => {
                entity.UserId = Guid.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                await repo.InsertAsync(mapper.Map<Address>(entity));
                return Results.Ok();})
                .WithTags("Creators");

            app.MapPut("/addresses",[Authorize] async ([FromBody] UpdateAddressDto entity, IGenericRepository<Address> repo, IMapper mapper) => {
                await repo.UpdateAsync(mapper.Map<Address>(entity));
                return Results.Accepted();})
                .WithTags("Updaters");

            app.MapDelete("/addresses/{id}",[Authorize] async (Guid id, IGenericRepository<Address> repo) => {
                await repo.DeleteAsync(await repo.GetAsync(id));
                return Results.NoContent();})
                .WithTags("Deletors");
        }
    }
}