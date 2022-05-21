using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace AuthApi.Apis
{
    public class UsersApi
    {
        private readonly ILogger<UsersApi> _logger;
        private readonly IMapper _mapper;
        private readonly IIdentityDetection _identity;
        private readonly IUserRepository _repository;

        public UsersApi(ILogger<UsersApi> logger, IMapper mapper, IIdentityDetection identity, IUserRepository repository)
        {
            _logger = logger;
            _mapper = mapper;
            _identity = identity;
            _repository = repository;
        }
        
        private static bool ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out validatedToken);
            return true;
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = false, // Because there is no expiration in the generated token
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = false,   // Because there is no issuer in the generated token
                ValidIssuer = "BD",
                ValidAudience = "BD",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BDCourseWork123123123123123123123")) // The same key as the one that generate the token
            };
        }

        public async void Register(WebApplication app)
        {

            app.MapPost("/signUp", [AllowAnonymous] async (SignUp dto) => {
                var token = await _repository.SignUp(dto);
                _logger.LogInformation($"AuthApi Request: SignUp, {@dto.Email} from {@_identity.GetIp()}");
                return token;
            });
                
            app.MapPost("/signIn", [AllowAnonymous] async (SignIn dto) => {
                var token = await _repository.SignIn(dto);
                _logger.LogInformation($"AuthApi Request: SignIn, {@dto.Email} from {@_identity.GetIp()}");
                return token;
            });
                
            app.MapDelete("", [Authorize] async ([FromQuery] string password) => {
                var id = _identity.GetUserId();
                await _repository.DeleteUser(id, password);
                _logger.LogInformation($"AuthApi Request: Delete, {@id} from {@_identity.GetIp()}");
            });
            
            app.MapPost("/retorePassword", [Authorize] async ([FromBody] RestorePassword dto) => {
                var token = await _repository.RestorePassword(dto);
                _logger.LogInformation($"AuthApi Request: RestorePassword, {@dto.Email} from {@_identity.GetIp()}");
            });

            app.MapGet("/user", [Authorize] async () => {
                var id = _identity.GetUserId();
                var user = _mapper.Map<UserVm>(await _repository.GetUserAsync(id));
                _logger.LogInformation($"AuthApi Request: GetUser, {@id} from {@_identity.GetIp()}");
                return user;
            });
            
            app.MapGet("/userDetails", [Authorize] async () => {
                var id = _identity.GetUserId();
                var user = _mapper.Map<UserDetailsVm>(await _repository.GetUserDetailsAsync(id));
                _logger.LogInformation($"AuthApi Request: GetUser, {@id} from {@_identity.GetIp()}");
                return user;
            });
            
            app.MapGet("/allUsers", [Authorize(Roles = "Admin")] async () => {
                var id = _identity.GetUserId();
                _logger.LogInformation($"AuthApi Request: GetUser, {@id} from {@_identity.GetIp()}");
                var users = _mapper.Map<List<UserVm>>(await _repository.GetAllUsersAsync());
            });

            app.MapGet("/auth", [Authorize] async () =>
            {
                var token = new HttpContextAccessor().HttpContext!.Request.Headers.Authorization.ToString()
                    .Replace("Bearer ", "");
                if (ValidateToken(token)) return token;
                throw new Exception("oops wrong token");
            });
        }
    }
}