using Application.Shop.Interfaces;
using Domain.Shop;
using Infrastructure.Shop.Data;

namespace Application.Shop.Repositories;

public class FormatRepository : GenericRepository<Format>, IFormatRepository
{
    public FormatRepository(ShopDbContext context) : base(context) { }
}