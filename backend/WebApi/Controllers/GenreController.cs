using Application.Shop.Interfaces;
using Domain.Shop;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers;

public class GenreController : GenericController<Genre>
{
    public GenreController(IGenericRepository<Genre> repository, ILogger<GenericController<Genre>> logger) : base(repository, logger)
    {
    }

    [Authorize(Roles = "Admin, Moderator")]
    public override Task DeleteAsync(Guid id)
    {
        return base.DeleteAsync(id);
    }

    [Authorize(Roles = "Admin, Moderator")]
    public override Task PostAsync(Genre entity)
    {
        return base.PostAsync(entity);
    }
}