using Domain.Models;

namespace Domain.Shop;

public class Disk : BaseEntity
{
    public string Name { get; set; }
    public string About { get; set; }
    public decimal Price { get; set; }
    public int Upc { get; set; }
    public string Img { get; set; }
    public DateTime Release { get; set; }
    public Guid ArtistId { get; set; }
    public Guid FormatId { get; set; }
    public Guid GenreId { get; set; }
    
    public Format? Format { get; set; }
    public Artist? Artist { get; set; }
    public Genre? Genre { get; set; }
    
    public ICollection<Bill> Bills { get; set; }
    public ICollection<Basket> Baskets { get; set; }
}