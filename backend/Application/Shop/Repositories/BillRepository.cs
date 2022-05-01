using Application.Shop.Interfaces;
using Domain.Shop;
using Infrastructure.Shop.Data;

namespace Application.Shop.Repositories;

public class BillRepository : GenericRepository<Bill>, IBillRepository
{
    public BillRepository(ShopDbContext context) : base(context) { }
}