namespace Domain.Models
{
    public class Email : BaseEntity
    {
        public string Name {get; set;}
        public bool Verified {get; set;} = false;
        public int Code {get; set;}
    }
}