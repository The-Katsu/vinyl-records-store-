namespace AuthApi.Application.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> GetAsync(Guid id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task InsertAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task DeleteAsync(T entity);
    }
}