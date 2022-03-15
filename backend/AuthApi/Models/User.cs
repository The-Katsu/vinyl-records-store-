namespace AuthApi.Models
{
    public class User : BaseEntity
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public Guid EmailId {get; set;}
        public string Password {get; set;}
        public Guid AddressId {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.UtcNow;
        public Role Role {get; set;} = Role.Customer;

        public virtual Email? Email {get; set;}
        public virtual Address? Address {get; set;}
    }

    public enum Role
    {
        Customer,
        Moderator,
        Admin
    }
}