namespace AuthApi.Models.DTO
{
    public class CreateCountryDto : IMapWith<Country>
    {
        public string Name {get; set;}

        public void Mapping(Profile profile) =>
            profile.CreateMap<CreateCountryDto, Country>();
    }
}