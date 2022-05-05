using Application.Shop.Interfaces;
using Domain.Shop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class BillController : GenericController<Bill>
{
    private readonly IGenericRepository<Bill> _repository;
    private readonly ILogger<GenericController<Bill>> _logger;
    private readonly IBillRepository _billRepository;
    public BillController(IGenericRepository<Bill> repository, ILogger<GenericController<Bill>> logger, IBillRepository billRepository) : base(repository, logger)
    {
        _repository = repository;
        _logger = logger;
        _billRepository = billRepository;
    }

    [Authorize]
    public override Task<IEnumerable<Bill>> GetAllAsync()
    {
        return base.GetAllAsync();
    }

    [Authorize]
    public override Task<Bill> GetByIdAsync(Guid id)
    {
        return base.GetByIdAsync(id);
    }

    [NonAction]
    public override Task PostAsync(Bill entity)
    {
        return base.PostAsync(entity);
    }

    [Authorize]
    [HttpPost]
    public async Task PostAsync([FromBody] Guid[] recordIds)
    {
        _billRepository.AddAsync(UserId, recordIds);
    }

    [NonAction]
    public override Task DeleteAsync(Guid id)
    {
        return base.DeleteAsync(id);
    }
}