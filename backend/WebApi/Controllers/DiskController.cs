using Application.Shop.Interfaces;
using Domain.Shop;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers;

public class DiskController : GenericController<Disk>
{
    public DiskController(IGenericRepository<Disk> repository, ILogger<GenericController<Disk>> logger) : base(repository, logger)
    {
    }

    [Authorize(Roles = "Admin, Moderator")]
    public override Task PostAsync(Disk entity)
    {
        return base.PostAsync(entity);
    }

    [Authorize(Roles = "Admin, Moderator")]
    public override Task DeleteAsync(Guid id)
    {
        return base.DeleteAsync(id);
    }
}