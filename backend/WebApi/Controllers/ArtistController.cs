using Application.Shop.Interfaces;
using Domain.Shop;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers;

public class ArtistController : GenericController<Artist>
{
    public ArtistController(IGenericRepository<Artist> repository, ILogger<GenericController<Artist>> logger) : base(repository, logger)
    {
    }

    [Authorize(Roles = "Admin, Moderator")]
    public override Task DeleteAsync(Guid id)
    {
        return base.DeleteAsync(id);
    }

    [Authorize(Roles = "Admin, Moderator")]
    public override Task PostAsync(Artist entity)
    {
        return base.PostAsync(entity);
    }
}