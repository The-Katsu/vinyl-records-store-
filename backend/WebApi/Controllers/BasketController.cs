using Application.Shop.Interfaces;
using Domain.Shop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class BasketController : GenericController<Basket>
{
    private readonly IGenericRepository<Basket> _repository;
    private readonly ILogger<GenericController<Basket>> _logger;
    
    public BasketController(IGenericRepository<Basket> repository, ILogger<GenericController<Basket>> logger) : base(repository, logger)
    {
        _repository = repository;
        _logger = logger;
    }

    [NonAction]
    public override Task<IEnumerable<Basket>> GetAllAsync()
    {
        return base.GetAllAsync();
    }

    [Authorize]
    public override Task<Basket> GetByIdAsync(Guid id)
    {
        return base.GetByIdAsync(id);
    }

    [NonAction]
    public override Task DeleteAsync(Guid id)
    {
        return base.DeleteAsync(id);
    }

    [Authorize]
    public override Task PostAsync(Basket basket)
    {
        return base.PostAsync(basket);
    }
}