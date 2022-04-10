namespace AuthApi.Application.Common.IdentityDetection
{
    public interface IIdentityDetection
    {
        Guid GetUserId();

        string GetIp();
    }
}