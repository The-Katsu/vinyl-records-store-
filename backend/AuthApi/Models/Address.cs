namespace AuthApi.Models
{
    public class Address : BaseEntity
    {
        public string Address1 {get; set;}
        public string? Address2 {get; set;}
        public Guid CityId {get; set;}
        public string District {get; set;}
        public int Postcode {get; set;}
        public string Phone {get; set;}

        public virtual City? City {get; set;}
    }
}