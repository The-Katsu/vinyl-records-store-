namespace AuthApi.Application.Implementations
{
    public class EmailRepository : IEmailRepository
    {
        private AuthDbContext _context;

        public EmailRepository(AuthDbContext context) => _context = context;

        private async Task Commit() => await _context.SaveChangesAsync();

        public async Task SendCode(string email, bool newPassword)
        {
            if (!newPassword)
                if(await _context.Emails.Where(e => e.Name == email && e.Verified == true).FirstOrDefaultAsync() != null)
                    throw new Exception("Email uses already");

            var rnd = new Random();
            var entity = new Email{Name = email, Code = rnd.Next(1000,9999)};

            using var mail = new MailMessage();
            mail.From = new MailAddress("VinylRecordsStore@gmail.com");
            mail.To.Add(email);
            mail.Subject = "Vinyl Records Store verification";
            mail.Body = $"<p> Dear customer</p> <br> <p> Your verify code is { entity.Code } </p>";
            mail.IsBodyHtml = true;

            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("MailCredit");
            using var client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential{UserName = config["login"], Password = config["password"]}
            };
            await client.SendMailAsync(mail);

            await _context.Emails.AddAsync(entity);
            await Commit();
        }

        public async Task<Guid> Verify(string email, int code)
        {
            var entity = await _context.Emails.OrderByDescending(e => e.LastUpdate).Where(e => string.Equals(e.Name, email)).FirstOrDefaultAsync();
            if (entity == null) throw new Exception("Wrong email");
            if (entity.Code != code) throw new Exception("Wrong code");
            entity.Verified = true;
            await Commit();
            return entity.Id;
        }
    }
}