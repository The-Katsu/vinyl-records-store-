using Application.Shop.Interfaces;
using Domain.Shop;

namespace WebApi.Controllers;

public class ArtistController : GenericController<Artist>
{
    public ArtistController(IGenericRepository<Artist> repository, ILogger<GenericController<Artist>> logger) : base(repository, logger)
    {
    }
}