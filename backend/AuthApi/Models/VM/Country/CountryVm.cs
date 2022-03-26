namespace Domain.Models.VM
{
    public class CountryVm : IMapWith<Country>
    {
        public Guid Id {get; set;}
        public string Name {get; set;}

        public void Mapping(Profile profile) =>
            profile.CreateMap<Country, CountryVm>();
    }
}