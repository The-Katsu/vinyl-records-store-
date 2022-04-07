namespace AuthApi.Apis
{
    public class UsersApi
    {
        private ILogger<UsersApi> _logger;
        private IHttpContextAccessor _context;
        private IMapper _mapper;
        private IIdentityDetection _identity;
        private IUserRepository _repository;

        public UsersApi(ILogger<UsersApi> logger, IHttpContextAccessor context, IMapper mapper, IIdentityDetection identity, IUserRepository repository)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _identity = identity;
            _repository = repository;
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
        }
    }
}