using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using DivulgueSuaPesquisa.Models;

namespace DivulgueSuaPesquisa.Services.EmailService;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;

    public EmailService(IConfiguration config)
    {
        _config = config;
    }

    public void SendEmail(EmailDTO request)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailCredentials:Username").Value));
        email.To.Add(MailboxAddress.Parse(_config.GetSection("EmailCredentials:Username").Value));
        email.Subject = request.Subject;
        email.Body = new TextPart(TextFormat.Plain) { Text = request.Body };

        using var smtp = new SmtpClient();
        smtp.Connect(_config.GetSection("EmailCredentials:Host").Value, 587, SecureSocketOptions.StartTls);
        smtp.Authenticate(_config.GetSection("EmailCredentials:Username").Value,
                          _config.GetSection("EmailCredentials:Password").Value);
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}
