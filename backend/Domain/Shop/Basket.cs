using Domain.Models;

namespace Domain.Shop;

public class Basket : BaseEntity
{
    public Guid UserId { get; set; }
    
    public ICollection<Disk>? Disks { get; set; }

    public Basket()
    {
        this.Disks = new List<Disk>();
    }
}