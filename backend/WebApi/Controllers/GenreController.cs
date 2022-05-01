using Application.Shop.Interfaces;
using Domain.Shop;

namespace WebApi.Controllers;

public class GenreController : GenericController<Genre>
{
    public GenreController(IGenericRepository<Genre> repository, ILogger<GenericController<Genre>> logger) : base(repository, logger)
    {
    }
}