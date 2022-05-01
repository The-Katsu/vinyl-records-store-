using Application.Shop.Interfaces;
using Domain.Shop;
using Infrastructure.Shop.Data;

namespace Application.Shop.Repositories;

public class BasketRepository : GenericRepository<Basket>, IBasketRepository
{
    public BasketRepository(ShopDbContext context) : base(context) { }
}