namespace AuthApi.Apis
{
    public class UsersApi
    {
        public void Register(WebApplication app)
        {
            app.MapPost("/signUp", [AllowAnonymous] async (SignUpDto dto, IUserRepository repo) => 
                await repo.SignUp(dto));
            
            app.MapPost("/signIn", [AllowAnonymous] async (SignInDto dto, IUserRepository repo) =>
                await repo.SignIn(dto));

            app.MapDelete("", [Authorize] async ([FromQuery] string password, HttpContext context, IUserRepository repo) =>
                await repo.DeleteUser(Guid.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier).Value), password));
        }
    }
}