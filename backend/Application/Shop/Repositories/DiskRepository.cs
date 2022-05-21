using Application.Shop.Interfaces;
using Domain.Shop;
using Infrastructure.Shop.Data;

namespace Application.Shop.Repositories;

public class DiskRepository : GenericRepository<Disk>, IDiskRepository
{
    private readonly ShopDbContext _context;
    public DiskRepository(ShopDbContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<Disk> GetByIdAsync(Guid id)
        => await _context.Disks
            .FirstAsync(x => x.Id == id);
}