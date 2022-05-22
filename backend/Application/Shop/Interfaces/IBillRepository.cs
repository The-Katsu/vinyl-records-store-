using Domain.Shop;

namespace Application.Shop.Interfaces;

public interface IBillRepository : IGenericRepository<Bill>
{
    public Task AddAsync(Guid userId);
    public Task<IEnumerable<Bill>> GetAsync(Guid userId);
}