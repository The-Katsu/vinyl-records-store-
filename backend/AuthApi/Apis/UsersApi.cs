namespace AuthApi.Apis
{
    public class UsersApi
    {
        public void Register(WebApplication app)
        {
            app.MapPost("/signUp", async (SignUpDto dto, IUserRepository repo) => 
                await repo.SignUp(dto));
            

        }
    }
}