namespace AuthApi.Application.Interfaces
{
    public interface IUserRepository
    {
        public Task<string> SignUp(SignUpDto dto);
        public Task<string> SignIn(SignInDto dto);
        public Task<string> RestorePassword(RestorePasswordDto dto);
        public Task DeleteUser(Guid id, string password);
    }
}