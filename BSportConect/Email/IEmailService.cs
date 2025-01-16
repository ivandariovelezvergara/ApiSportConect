namespace BSportConect.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body, bool isBodyHtml);
        Task<string> LoadHtmlTemplate(string filePath);
    }
}
