namespace Domain.Models.DTO
{
    public class CreateCityDto : IMapWith<City>
    {
        public string Name {get; set;}
        public Guid CountryId {get; set;}
        public void Mapping(Profile profile) =>
            profile.CreateMap<CreateCityDto, City>();
    }
}