using Application.Shop.Interfaces;
using Domain.Shop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class DiskController : GenericController<Disk>
{
    private readonly IDiskRepository _recordRepository;
    public DiskController(IGenericRepository<Disk> repository, ILogger<DiskController> logger, IDiskRepository recordRepository) : base(repository, logger)
    {
        _recordRepository = recordRepository;
    }

    [HttpGet("/{id:guid}")]
    public async Task<ActionResult<Disk>> GetById(Guid id)
    {
        var record = await _recordRepository.GetByIdAsync(id);
        return record;
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

    [NonAction]
    public override Task<Disk> GetByIdAsync(Guid id)
    {
        return base.GetByIdAsync(id);
    }
}