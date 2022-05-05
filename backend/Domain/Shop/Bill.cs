using Domain.Models;

namespace Domain.Shop;

public class Bill : BaseEntity
{
    public Guid UserId { get; set; }
    public DateTime OrderedAt { get; set; } = DateTime.Now;
    
    public ICollection<Disk> Disks { get; set; }
}