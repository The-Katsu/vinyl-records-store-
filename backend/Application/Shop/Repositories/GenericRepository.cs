using Infrastructure.Shop.Data;

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

    public virtual async Task<T> GetByIdAsync(Guid id)
        => await _dbSet.FindAsync(id);

    public virtual async Task AddAsync(T entity)
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

    public async Task Commit() 
        => await _context.SaveChangesAsync();
}