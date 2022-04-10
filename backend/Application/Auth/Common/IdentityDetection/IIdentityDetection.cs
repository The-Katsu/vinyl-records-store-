namespace AuthApi.Application.Common.IdentityDetection
{
    public class IdentityDetection : IIdentityDetection
    {
        private IHttpContextAccessor _context;

        public IdentityDetection(IHttpContextAccessor context)
            => _context = context;

        public Guid GetUserId() => Guid.Parse(_context.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

        public string GetIp() => _context.HttpContext.Connection.RemoteIpAddress.ToString();
    }
}