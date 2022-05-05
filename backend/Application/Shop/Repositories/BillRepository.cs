using Application.Shop.Interfaces;
using Domain.Shop;
using Infrastructure.Shop.Data;

namespace Application.Shop.Repositories;

public class BillRepository : GenericRepository<Bill>, IBillRepository
{
    private readonly ShopDbContext _context;

    public BillRepository(ShopDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task AddAsync(Guid userId, Guid[] recordIds)
    {
        await _context.Bills.AddAsync(new Bill{UserId = userId});
        await AddRecords(userId, recordIds);
        await RemoveFromBasket(userId, recordIds);
    }

    private async Task RemoveFromBasket(Guid userId, Guid[] recordIds)
    {
        var basket = await _context.Baskets
            .FirstAsync(x => x.UserId == userId);

        foreach (var recordId in recordIds) 
            basket.Disks.Remove(await _context.Disks.FindAsync(recordId));
    }
    
    private async Task AddRecords(Guid userId, Guid[] recordIds)
    {
        var bill = await _context.Bills
            .FirstAsync(x => x.UserId == userId);

        var records = new List<Disk>();

        foreach (var recordId in recordIds)
            records.Add(await _context.Disks
                .FindAsync(recordId));

        foreach (var record in records)
            bill.Disks.Add(record);

        await Commit();
    }

    private async Task Commit() => await _context.SaveChangesAsync();
}