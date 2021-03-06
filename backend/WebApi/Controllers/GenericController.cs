using System.Security.Claims;
using Application.Shop.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

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