using Application.Shop.Interfaces;
using Domain.Shop;

namespace WebApi.Controllers;

public class FormatController : GenericController<Format>
{
    public FormatController(IGenericRepository<Format> repository, ILogger<GenericController<Format>> logger) : base(repository, logger)
    {
    }
}