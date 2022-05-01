using Application.Shop.Interfaces;
using Domain.Shop;
using Infrastructure.Shop.Data;

namespace Application.Shop.Repositories;

public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
{
    public ArtistRepository(ShopDbContext context) : base(context) { }
}