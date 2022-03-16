namespace AuthApi.Application.Interfaces
{
    public interface IEmailRepository
    {
        public Task SendCode(string email);
        public Task<Guid> Verify(string email, int code);
    }
}