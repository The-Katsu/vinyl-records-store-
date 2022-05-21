using Domain.Models;
using Newtonsoft.Json;

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
    
    [JsonIgnore]
    public Format? Format { get; set; }
    [JsonIgnore]
    public Artist? Artist { get; set; }
    [JsonIgnore]
    public Genre? Genre { get; set; }
    
    [JsonIgnore]
    public ICollection<Bill?>? Bills { get; set; }
    [JsonIgnore]
    public ICollection<Basket?>? Baskets { get; set; }
}