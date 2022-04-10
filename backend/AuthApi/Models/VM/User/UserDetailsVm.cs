namespace Domain.Models.VM
{
    
    public class UserDetailsVm : IMapWith<User>
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string Role {get; set;}
        public AddressVm Address{get; set;}

        public void Mapping(Profile profile) => 
            profile.CreateMap<User, UserDetailsVm>()
                .ForMember(vm => vm.Email, 
                entity => entity.MapFrom(e => e.Email.Name))
                .ForMember(vm => vm.Address, 
                entity => entity.MapFrom(e => e.Address));
    }
}