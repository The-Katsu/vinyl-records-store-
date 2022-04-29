namespace Domain.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id {get; set;} = Guid.NewGuid();
        public DateTime LastUpdate {get; set;} = DateTime.UtcNow; 
    }
}