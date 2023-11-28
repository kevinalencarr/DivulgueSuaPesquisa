using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using DivulgueSuaPesquisa.Models;
using DivulgueSuaPesquisa.Services.ViewRenderService;

namespace DivulgueSuaPesquisa.Services.EmailService;

public class EmailService : IEmailService
{
    private readonly IConfiguration _config;
    private readonly IViewRenderService _viewRenderService;

    public EmailService(IConfiguration config, IViewRenderService viewRenderService)
    {
        _config = config;
        _viewRenderService = viewRenderService;
    }

    public void SendEmail(EmailDto request)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailCredentials:Username").Value));
        email.To.Add(MailboxAddress.Parse(_config.GetSection("EmailCredentials:Username").Value));
        email.To.Add(MailboxAddress.Parse(request.ContactEmail));
        email.Subject = request.Subject;
        
        var body = _viewRenderService.RenderToString("Templates/EmailTemplate", request);
        email.Body = new TextPart(TextFormat.Html) { Text = body };
        
        using var smtp = new SmtpClient();
        smtp.Connect(_config.GetSection("EmailCredentials:Host").Value, 587, SecureSocketOptions.StartTls);
        smtp.Authenticate(_config.GetSection("EmailCredentials:Username").Value,
                          _config.GetSection("EmailCredentials:Password").Value);
        smtp.Send(email);
        smtp.Disconnect(true);
    }
}
