using Application.Shop.Interfaces;
using Domain.Shop;
using Infrastructure.Shop.Data;

namespace Application.Shop.Repositories;

public class BasketRepository : GenericRepository<Basket>, IBasketRepository
{
    private readonly ShopDbContext _context;
    public BasketRepository(ShopDbContext context) : base(context)
    {
        _context = context;
    }


    public async Task<Basket> GetAsync(Guid userId)
    {
        if (!await _context.Baskets.AnyAsync(x => x.UserId == userId))
        {
            await _context.Baskets.AddAsync(new Basket {UserId = userId});
            await Commit();
        }
        
        return await _context.Baskets
            .Include(x => x.Disks)
            .FirstAsync(x => x.UserId == userId);
    }

    public async Task AddToBasket(Guid recordId, Guid userId)
    {
        if (!await _context.Baskets.AnyAsync(x => x.UserId == userId))
            await _context.Baskets.AddAsync(new Basket {UserId = userId});
        
        var basket = await _context.Baskets
            .FirstAsync(x => x.UserId == userId);

        basket.Disks.Add(await _context.Disks
            .FirstAsync(x => x.Id == recordId));

        await Commit();
    }

    private async Task Commit() => await _context.SaveChangesAsync();
}