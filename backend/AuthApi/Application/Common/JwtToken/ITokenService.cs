namespace AuthApi.Application.Common.JwtToken
{
    public interface ITokenService
    {
        string BuildToken(string key, string issuer, User user); 
    }
}