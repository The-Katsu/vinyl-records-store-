using Application.Shop.Interfaces;
using Domain.Shop;

namespace WebApi.Controllers;

public class DiskController : GenericController<Disk>
{
    public DiskController(IGenericRepository<Disk> repository, ILogger<GenericController<Disk>> logger) : base(repository, logger)
    {
    }
}