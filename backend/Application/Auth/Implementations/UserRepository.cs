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

        private string BuildToken(User user)
        {
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

        public async Task<string> RestorePassword(RestorePassword dto)
        {
            var user = await _context.Users.Where(e => e.Email.Name == dto.Email).FirstOrDefaultAsync();

            var emailId = await _email.Verify(dto.Email, dto.Code);

            if (emailId != user.EmailId)
                throw new Exception($"AuthApi response: Verifycation not accepted {dto.Email}");

            user.Password = dto.Password;

            await Commit();

            return BuildToken(user);
        }

        public async Task<string> SignIn(SignIn dto)
        {
            var user = await _context.Users.Where(e => e.Email.Name == dto.Email).FirstOrDefaultAsync();

            if (user == null)
                throw new Exception($"AuthApi response: Wrong Email - {dto.Email}");

            if (!Hash.VerifyHashedPassword(user.Password, dto.Password))
                throw new Exception($"AuthApi response: Wrong password - {dto.Email}");

            return BuildToken(user);
        }

        public async Task<string> SignUp(SignUp dto)
        {
            var emailId = await _email.Verify(dto.Email, dto.Code);

            if(_context.Users.Where(e => e.Email.Name == _context.Emails.Where(e => e.Id == emailId).Select(e => e.Name).Single()).Count() != 0 )
                throw new Exception($"AuthApi response: Email already using - {dto.Email}");

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                EmailId = emailId,
                Password = Hash.HashPassword(dto.Password)
            };

            await _context.Users.AddAsync(user);
            await Commit();

            return BuildToken(user);
        }

        public async Task DeleteUser(Guid id, string password)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                throw new Exception($"AuthApi response: User not found for {id}");

            if (!Hash.VerifyHashedPassword(user.Password, password))
                throw new Exception($"AuthApi response: Wrong password for {id}");

            var email = await _context.Emails.FindAsync(user.EmailId);

            email.Verified = false;

            _context.Users.Remove(user);

            await Commit();
        }

        public async Task<User> GetUserAsync(Guid id) => await _context.Users.Include(e => e.Email).Where(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<User> GetUserDetailsAsync(Guid id) => await _context.Users.Include(e => e.Email).Include(e => e.Address).ThenInclude(e => e.City).Where(e => e.Id == id).FirstOrDefaultAsync();
        public async Task<List<User>> GetAllUsersAsync()=> await _context.Users.Include(e => e.Email).ToListAsync();
    }
}