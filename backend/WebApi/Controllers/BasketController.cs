using Application.Shop.Interfaces;
using Domain.Shop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class BasketController : GenericController<Basket>
{
    private readonly IGenericRepository<Basket> _repository;
    private readonly ILogger<GenericController<Basket>> _logger;
    private readonly IBasketRepository _basketRepository;
    
    public BasketController(IGenericRepository<Basket> repository, ILogger<GenericController<Basket>> logger, IBasketRepository basketRepository) : base(repository, logger)
    {
        _repository = repository;
        _logger = logger;
        _basketRepository = basketRepository;
    }

    [NonAction]
    public override Task<IEnumerable<Basket>> GetAllAsync()
    {
        return base.GetAllAsync();
    }

    [NonAction]
    public override Task<Basket> GetByIdAsync(Guid id)
    {
        return base.GetByIdAsync(id);
    }

    [Authorize]
    [HttpGet]
    public async Task<Basket> GetByIdAsync()
    {
        return await _basketRepository.GetAsync(UserId);
    }

    [NonAction]
    public override Task DeleteAsync(Guid id)
    {
        return base.DeleteAsync(id);
    }

    [Authorize]
    [HttpPost]
    public async Task PostAsync(Guid recordId)
    {
        await _basketRepository.AddToBasket(recordId, UserId);
    }
    
    [NonAction]
    public override Task PostAsync(Basket basket)
    {
        return base.PostAsync(basket);
    }
}