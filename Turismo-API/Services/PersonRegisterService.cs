using System.Net.Mail;
using Turismo_API.Data;
using Turismo_API.Models;
using Turismo_API.Services.Interfaces;

namespace Turismo_API.Services
{
    public class PersonRegisterService : IPersonRegisterService
    {
        private readonly BdTurismoTiquipayaContext _context;
        public PersonRegisterService(BdTurismoTiquipayaContext context) 
        {
            _context = context;
        }
        public async Task RegisterPersonRegister(int personID, int userID)
        {
            try
            {
                PersonRegister personRegister = new PersonRegister
                {
                    PersonId = personID,
                    UserPersonId = userID
                };
                await _context.PersonRegisters.AddAsync(personRegister);
                await _context.SaveChangesAsync();
            }
            catch
            {
                return;
            }
        }

        public async Task SendEmail(string username, string emailDestiny)
        {
            string EmailOrigin = "berriosanderson807@gmail.com";
            string password = "glmy njqu mzsv ldly";
            MailMessage mailMessage = new MailMessage(EmailOrigin, emailDestiny, "Bienvenido a Turismo Tiquipaya!",
                "<p>Nombre de Usuario: </p><br />" +
                username);
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

    }
}