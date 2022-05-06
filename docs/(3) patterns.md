# Паттерны проектирования для работы с БД  
## Паттерн репозиториев с обобщениями  
Интерфейс:  
```cs
public interface IGenericRepository<T> where T : class
{
    public Task<T> GetAsync(Guid id);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task InsertAsync(T entity);
    public Task UpdateAsync(T entity);
    public Task DeleteAsync(T entity);
}
```
Реализация:  
```cs
public class GenericRepository<T> : IGenericRepository<T> 
    where T : class
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
```  
Контроллер:  
```cs  
[ApiController]
[Route("api/[controller]")]
public class GenericController<T> : ControllerBase where T : class
{
    private readonly IGenericRepository<T> _repository;
    private readonly ILogger<GenericController<T>> _logger;

    public GenericController(IGenericRepository<T> repository, ILogger<GenericController<T>> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    protected Guid UserId => !User.Identity.IsAuthenticated
        ? Guid.Empty
        : Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

    [HttpGet]
    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();   
        _logger.LogInformation("ShopApi: GetAll {Name} from {RemoteIpAddress}",
            typeof(T).Name, HttpContext.Connection.RemoteIpAddress);
        return entities;
    }
        

    [HttpGet("{id:guid}")]
    public virtual async Task<T> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        _logger.LogInformation("ShopApi: GetById {Name} with {Id} from {RemoteIpAddress}",
            typeof(T).Name, id.ToString(), HttpContext.Connection.RemoteIpAddress);
        return entity;
    }

    [HttpPost]
    public virtual async Task PostAsync([FromBody] T entity)
    {
        await _repository.AddAsync(entity);
        _logger.LogInformation("ShopApi: Post {Name} from {RemoteIpAddress}", 
            typeof(T).Name, HttpContext.Connection.RemoteIpAddress);
    }

    [HttpDelete("{id:guid}")]
    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);
        _logger.LogInformation("ShopApi: Delete {Name} from {RemoteIpAddress}",
            typeof(T).Name, HttpContext.Connection.RemoteIpAddress);    
        await _repository.DeleteAsync(id);
    }
}
```