namespace AuthApi.Models.DTO
{
    public class UpdateCountryDto : IMapWith<Country>
    {
        public Guid Id {get; set;}
        public string Name {get; set;}

        public void Mapping(Profile profile) =>
            profile.CreateMap<UpdateCountryDto, Country>();
    }
}