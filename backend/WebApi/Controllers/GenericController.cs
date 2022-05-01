
using Application.Shop.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class GenericController<T> : Controller where T : class
{
    private readonly IGenericRepository<T> _repository;
    
    public GenericController(IGenericRepository<T> repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public async Task<IEnumerable<T>> GetAllAsync() 
        => await _repository.GetAllAsync();

    [HttpGet("/{id}")]
    public async Task<T> GetAsync(Guid id) 
        => await _repository.GetByIdAsync(id);

    [HttpPost]
    public async Task PostAsync([FromBody]T entity) 
        => await _repository.AddAsync(entity);

    [HttpDelete("/{id}")]
    public async Task DeleteAsync(Guid id)
        => await _repository.DeleteAsync(id);
}