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

            // app.MapDelete("", [Authorize] async (IUserRepository repo) => {
            //     var userId = Guid.Parse(new HttpContext().User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //     var userId = new HttpContent().});
        }
    }
}