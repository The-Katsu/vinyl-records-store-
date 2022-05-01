using Application.Shop.Interfaces;
using Domain.Shop;
using Infrastructure.Shop.Data;

namespace Application.Shop.Repositories;

public class DiskRepository : GenericRepository<Disk>, IDiskRepository
{
    public DiskRepository(ShopDbContext context) : base(context) { }
}