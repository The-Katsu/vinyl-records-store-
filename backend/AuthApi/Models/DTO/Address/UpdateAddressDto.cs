namespace Domain.Models.DTO
{
    public class UpdateAddressDto : IMapWith<Address>
    {
        public Guid Id {get; set;}
        public string Address1 {get; set;}
        public string? Address2 {get; set;}
        public Guid CityId {get; set;}
        public string District {get; set;}
        public int Postcode {get; set;}
        public string Phone {get; set;}
        public void Mapping(Profile profile) =>
            profile.CreateMap<UpdateAddressDto, Address>();
    }
}