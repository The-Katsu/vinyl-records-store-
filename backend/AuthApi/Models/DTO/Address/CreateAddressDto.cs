namespace Domain.Models.DTO
{
    public class CreateAddressDto : IMapWith<Address>
    {
        public string Address1 {get; set;}
        public string? Address2 {get; set;}
        public Guid CityId {get; set;}
        public string District {get; set;}
        public int Postcode {get; set;}
        public string Phone {get; set;}
        [JsonIgnore]
        public Guid UserId {get; set;}
        public void Mapping(Profile profile) =>
            profile.CreateMap<CreateAddressDto, Address>();
    }
}