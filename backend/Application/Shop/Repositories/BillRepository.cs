using Application.Shop.Interfaces;
using Domain.Shop;
using Infrastructure.Shop.Data;

namespace Application.Shop.Repositories;

public class BillRepository : GenericRepository<Bill>, IBillRepository
{
    private readonly ShopDbContext _context;
    private readonly AuthDbContext _authDbContext;

    public BillRepository(ShopDbContext context, AuthDbContext authDbContext) : base(context)
    {
        _context = context;
        _authDbContext = authDbContext;
    }

    public async Task AddAsync(Guid userId)
    {
        var basket = await _context.Baskets
            .Include(x => x.Disks)
            .ThenInclude(x => x.Artist)
            .FirstAsync(x => x.UserId == userId);

        var disks = basket.Disks;
        
        var sb = new StringBuilder();
        decimal sumPrice = 0;
        foreach (var disk in disks)
        {
            sumPrice += disk.Price;
            sb.Append($"<p>{disk.Name} by {disk.Artist.Name} for {disk.Price} rub</p>");
        }

        if (disks.Count == 0) throw new ArgumentNullException("Basket is empty");
        
        var bill = new Bill {UserId = userId};
        await _context.Bills.AddAsync(bill);
        await Commit();

        bill = await _context.Bills
            .OrderByDescending(x => x.OrderedAt)
            .FirstAsync(x => x.UserId == userId);

        foreach (var disk in disks)
            bill.Disks.Add(disk);

        foreach (var disk in basket.Disks.ToList())
            basket.Disks.Remove(disk);

        var user = await _authDbContext.Users
            .Include(x => x.Email)
            .FirstAsync(x => x.Id == userId);

        using var mail = new MailMessage();
        mail.From = new MailAddress("VinylRecordsStore@gmail.com");
        mail.To.Add(user.Email.Name);
        mail.Subject = "Vinyl Records Store verification";
        mail.Body = $"<p> Dear customer, Thank you for purchase.</p> <br> <p>Your check for {sumPrice} rub: {sb.ToString()} </p>";
        mail.IsBodyHtml = true;

        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("MailCredit");
        using var client = new SmtpClient()
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential{UserName = config["login"], Password = config["password"]}
        };
        await client.SendMailAsync(mail);
        
        await Commit();
    }

    public async Task<IEnumerable<Bill>> GetAsync(Guid userId)
    {
        return await _context.Bills
            .Include(x => x.Disks)
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task SendEmail(Guid userId)
    {
        var user = await _authDbContext.Users
            .Include(x => x.Email)
            .FirstAsync(x => x.Id == userId);
    }

    private async Task Commit() => await _context.SaveChangesAsync();
}