namespace AuthApi.Application.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private AuthDbContext _context;
        private DbSet<T> _dbSet;

        public GenericRepository(AuthDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        private async Task Commit() => await _context.SaveChangesAsync();

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task<T> GetAsync(Guid id) => await _dbSet.FindAsync(id);

        public async Task InsertAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await Commit();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await Commit();
        }
        
        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await Commit();
        }
    }
}