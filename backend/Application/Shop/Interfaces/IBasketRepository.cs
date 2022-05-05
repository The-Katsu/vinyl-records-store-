using Domain.Shop;

namespace Application.Shop.Interfaces;

public interface IBasketRepository : IGenericRepository<Basket>
{
    public Task AddToBasket(Guid recordId, Guid userId);
}