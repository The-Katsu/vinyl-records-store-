namespace AuthApi.Apis
{
    public class UsersApi
    {
        public async void Register(WebApplication app)
        {
            app.MapPost("/signUp", [AllowAnonymous] async (SignUp dto, IUserRepository repo) => 
                await repo.SignUp(dto));
            
            app.MapPost("/signIn", [AllowAnonymous] async (SignIn dto, IUserRepository repo) =>
                await repo.SignIn(dto));

            app.MapDelete("", [Authorize] async ([FromQuery] string password, HttpContext context, IUserRepository repo) =>
                await repo.DeleteUser(Guid.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier).Value), password));
            
            app.MapPost("/retorePassword", [Authorize] async ([FromBody] RestorePassword dto, IUserRepository repo) => 
                await repo.RestorePassword(dto));

            app.MapGet("/user", [Authorize] async (HttpContext context, IUserRepository repo, IMapper mapper) =>
                mapper.Map<UserVm>(await repo.GetUserAsync(Guid.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier).Value))));
            
            app.MapGet("/allUsers", [Authorize(Roles = "Admin")] async (IUserRepository repo, IMapper mapper) => 
                mapper.Map<List<UserVm>>(await repo.GetAllUsersAsync()));
        }
    }
}