namespace AuthApi.Application.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _context;
        private IEmailRepository _email;
        private readonly ITokenService _token;

        public UserRepository(AuthDbContext context, ITokenService token, IEmailRepository email) 
        {
            _context = context;
            _token = token;
            _email = email;
        }

        public Task<string> RestorePassword(RestorePasswordDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<string> SignIn(SignInDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SignUp(SignUpDto dto)
        {
            var emailId = await _email.Verify(dto.Email, dto.Code);

            if(_context.Users.Where(e => e.Email.Name == _context.Emails.Where(e => e.Id == emailId).Select(e => e.Name).Single()).Count() != 0 )
                throw new Exception("User with that email already exists");

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                EmailId = emailId,
                Password = Hash.HashPassword(dto.Password)
            };

            await _context.Users.AddAsync(user);
            await Commit();

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("Jwt");

            return _token.BuildToken(config["Key"], config["Issuer"], user);
        }

        private async Task Commit() => await _context.SaveChangesAsync();

        private bool PasswordValidation(string password)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            return hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && hasMinimum8Chars.IsMatch(password);
        }
    }
}