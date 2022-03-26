namespace Domain.Models.VM
{
    public class UserVm : IMapWith<User>
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}

        public void Mapping(Profile profile) => 
            profile.CreateMap<User, UserVm>()
                .ForMember(vm => vm.Email, 
                entity => entity.MapFrom(e => e.Email.Name));
    }
}