using Domain.Models;

namespace Domain.Shop;

public class Bill : BaseEntity
{
    public Guid UserId { get; set; }
    public DateTime OrderedAt { get; set; } = DateTime.UtcNow;
    
    public ICollection<Disk> Disks { get; set; }

    public Bill()
    {
        this.Disks = new List<Disk>();
    }
}