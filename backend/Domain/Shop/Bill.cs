using Domain.Models;

namespace Domain.Shop;

public class Bill : BaseEntity
{
    public Guid UserId { get; set; }
    public string Address { get; set; }
    public DateTime OrderedAt { get; set; } = DateTime.Now;
    public DateTime? DeliveredAt { get; set; } = null;
    
    public ICollection<Disk> Disks { get; set; }
}