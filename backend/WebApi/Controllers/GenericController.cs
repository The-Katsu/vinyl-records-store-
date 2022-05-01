using System.Security.Claims;
using Application.Shop.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
public class GenericController<T> : Controller where T : class
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
        => await _repository.GetAllAsync();

    [HttpGet("{id:guid}")]
    public virtual async Task<T> GetByIdAsync(Guid id) 
        => await _repository.GetByIdAsync(id);

    [HttpPost]
    public virtual async Task PostAsync([FromBody] T entity)
    {
        _logger.LogInformation("ShopApi: Post {Name} from {RemoteIpAddress}", 
            entity.GetType().Name, HttpContext.Connection.RemoteIpAddress);
        await _repository.AddAsync(entity);
    }
    [HttpDelete("{id:guid}")]
    public virtual async Task DeleteAsync(Guid id)
        => await _repository.DeleteAsync(id);
}