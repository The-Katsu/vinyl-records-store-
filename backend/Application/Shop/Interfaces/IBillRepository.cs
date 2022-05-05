using Domain.Shop;

namespace Application.Shop.Interfaces;

public interface IBillRepository : IGenericRepository<Bill>
{
    public Task AddAsync(Guid userId, Guid[] records);
}