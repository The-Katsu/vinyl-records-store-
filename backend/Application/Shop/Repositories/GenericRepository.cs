using Infrastructure.Shop.Data;
using Application.Shop.Interfaces;
using Microsoft.Extensions.Logging;

namespace Application.Shop.Repositories;

public class GenericRepository<T> : Interfaces.IGenericRepository<T> where T : class
{
    private readonly ShopDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ShopDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
        => await _dbSet.ToListAsync();

    public async Task<T> GetByIdAsync(Guid id)
        => await _dbSet.FindAsync(id);

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await Commit();
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var e = await GetByIdAsync(id);
        _dbSet.Remove(e);
        await Commit();
    }

    private async Task Commit() 
        => await _context.SaveChangesAsync();
}