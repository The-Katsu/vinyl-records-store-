using Application.Shop.Interfaces;
using Domain.Shop;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers;

public class FormatController : GenericController<Format>
{
    public FormatController(IGenericRepository<Format> repository, ILogger<GenericController<Format>> logger) : base(repository, logger)
    {
    }

    [Authorize(Roles = "Admin, Moderator")]
    public override Task PostAsync(Format entity)
    {
        return base.PostAsync(entity);
    }

    [Authorize(Roles = "Admin, Moderator")]
    public override Task DeleteAsync(Guid id)
    {
        return base.DeleteAsync(id);
    }
}