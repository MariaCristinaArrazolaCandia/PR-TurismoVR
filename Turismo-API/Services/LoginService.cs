using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using Turismo_API.Data;
using Turismo_API.Models.Custom;
using Turismo_API.Services.Interfaces;

namespace Turismo_API.Services
{
    public class LoginService : ILoginService
    {
        private readonly BdTurismoTiquipayaContext _context;
        private readonly IConfiguration _config;

        public LoginService(BdTurismoTiquipayaContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public string GenerateUserName(string Name, string lastName, string Email, string Ci)
        {
            string charName = Name.Substring(0, 2).ToLower();
            string charLastName = lastName.Substring(0, 2).ToLower();
            string charEmail = Email.Substring(0, 3).ToLower();
            string charci = Ci.Substring(0, 2).ToLower();

            string UserName = string.Concat(charName, charLastName, charEmail, charci);
            return UserName;
        }

        public async Task<AuthResponse> Login(UserRequest user)
        {
            var userFinded = _context.Users.FirstOrDefault(x =>
            x.Email==user.email && x.Password==user.password || x.UserName == user.userName && x.Password == user.password);

            if (userFinded == null)
                return await Task.FromResult<AuthResponse>(null);

            var person = _context.People.Find(userFinded.PersonId);

            string fullname = person.Name + " " + person.FirstName;

            return new AuthResponse() { userID = userFinded.PersonId, fullName = fullname, Rol = userFinded.Rol };
        }


        public string EncryptPassword(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        public async Task<bool> GetCode(string email, string username)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == email && x.UserName == username);
            
            if (user == null)
                return false;

            try
            {
                string code = GenerateCode();
                user.CodeRecovery = EncryptPassword(code);
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                await SendCode(email, code);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GenerateCode()
        {
            var code = Guid.NewGuid().ToString().Split("-")[0];

            return code;
        }

        private async Task SendCode(string email, string code)
        {
            string EmailOrigin = "berriosanderson807@gmail.com";
            string password = "glmy njqu mzsv ldly";

            MailMessage mailMessage = new MailMessage(EmailOrigin, email, "Turismo Tiquipaya - Código de Recuperación",
                "<p>Su codigo de Recuperacón es: </p><br />" +
                code);

            mailMessage.IsBodyHtml = true;

            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
            {
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Port = 587;
                smtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigin, password);

                await smtpClient.SendMailAsync(mailMessage);
            }
        }

        public async Task<bool> ChangePassword(ChangePasswordDTO changePassword)
        {
            string encrypted = EncryptPassword(changePassword.Code);
            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.Email == changePassword.Email && x.CodeRecovery == encrypted);

            if (user == null)
                return false;

            try
            {
                user.Password = EncryptPassword(changePassword.Password);
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch(DbUpdateConcurrencyException)
            {
                return false;
            }
        }
    }
}
