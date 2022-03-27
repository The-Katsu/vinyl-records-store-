namespace AuthApi.Application.Interfaces
{
    public class RestorePassword
    {
        public string Email { get; set; }
        public int Code { get; set; }
        public string Password { get; set; }
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}