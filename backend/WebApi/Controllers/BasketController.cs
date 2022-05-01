using Application.Shop.Interfaces;
using Domain.Shop;

namespace WebApi.Controllers;

public class BasketController : GenericController<Basket>
{
    public BasketController(IGenericRepository<Basket> repository, ILogger<GenericController<Basket>> logger) : base(repository, logger)
    {
    }
}