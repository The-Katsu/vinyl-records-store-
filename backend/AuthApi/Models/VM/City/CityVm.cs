namespace Domain.Models.VM
{
    public class CityVm : IMapWith<City>
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public Guid CountryId {get; set;}

        public void Mapping(Profile profile) => 
            profile.CreateMap<City, CityVm>();
    }
}