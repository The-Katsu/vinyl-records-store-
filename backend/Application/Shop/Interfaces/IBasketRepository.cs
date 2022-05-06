using Domain.Shop;

namespace Application.Shop.Interfaces;

public interface IBasketRepository : IGenericRepository<Basket>
{
    public Task<Basket> GetAsync(Guid userId);
    public Task AddToBasket(Guid recordId, Guid userId);
}