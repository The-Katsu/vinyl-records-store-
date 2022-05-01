using Application.Shop.Interfaces;
using Domain.Shop;

namespace WebApi.Controllers;

public class BillController : GenericController<Bill>
{
    public BillController(IGenericRepository<Bill> repository, ILogger<GenericController<Bill>> logger) : base(repository, logger)
    {
    }
}