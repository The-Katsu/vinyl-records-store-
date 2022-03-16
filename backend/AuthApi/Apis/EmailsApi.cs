namespace AuthApi.Apis
{
    public class EmailsApi
    {
        public void Register(WebApplication app)
        {
            app.MapPost("/sendCode", async ([FromQuery] string email, IEmailRepository repo) => {
                await repo.SendCode(email);
                return Results.Ok();})
                .WithTags("EmailApi");

            app.MapGet("/verifyEmail", async ([FromQuery] string email, [FromQuery] int code, IEmailRepository repo) => 
                await repo.Verify(email, code))
                .WithTags("EmailApi");
        }
    }   
}