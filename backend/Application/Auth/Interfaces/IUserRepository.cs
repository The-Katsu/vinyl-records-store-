namespace AuthApi.Application.Interfaces
{
    public interface IUserRepository
    {
        public Task<string> SignUp(SignUp dto);
        public Task<string> SignIn(SignIn dto);
        public Task<string> RestorePassword(RestorePassword dto);
        public Task DeleteUser(Guid id, string password);
        public Task<User> GetUserAsync(Guid id);
        public Task<List<User>> GetAllUsersAsync();
    }
}