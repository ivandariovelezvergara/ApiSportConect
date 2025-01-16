using Entity.AppSettings;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BSportConect.Email.Service
{
    public class EmailService : IEmailService
    {
        private readonly Entity.AppSettings.Email _emailSettings;

        public EmailService(IOptions<Entity.AppSettings.Email> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async Task SendEmailAsync(string to, string subject, string body, bool isBodyHtml)
        {
            try
            {
                using var smtpClient = new SmtpClient(_emailSettings.SMTPHost, _emailSettings.SMTPPort)
                {
                    Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.SenderPassword),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_emailSettings.SenderEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = isBodyHtml
                };

                mailMessage.To.Add(to);

                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                // Registro detallado del error
                Console.WriteLine($"Error al enviar correo: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
                throw;
            }
        }

        public async Task<string> LoadHtmlTemplate(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"El archivo de plantilla HTML no se encontró: {filePath}");
            }

            return File.ReadAllText(filePath);
        }
    }
}
