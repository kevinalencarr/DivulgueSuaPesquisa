using DivulgueSuaPesquisa.Models;

namespace DivulgueSuaPesquisa.Services.EmailService;

public interface IEmailService
{
    void SendEmail(EmailDTO request);
}