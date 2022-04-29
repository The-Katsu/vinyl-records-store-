using Domain.Models;

namespace Domain.Shop;

public class Artist : BaseEntity
{
    public string Name { get; set; }
    public string Bio { get; set; }
}