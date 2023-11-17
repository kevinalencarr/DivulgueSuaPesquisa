using DivulgueSuaPesquisa.Models;
using DivulgueSuaPesquisa.Services.EmailService;
using Microsoft.AspNetCore.Mvc;

namespace DivulgueSuaPesquisa.Controllers;

[Route("[controller]")]
public class EmailController : Controller
{
    private readonly IEmailService _emailService;

    public EmailController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost]
    [Route("SendEmail")]
    public IActionResult SendEmail([FromBody] EmailDto request)
    {
        _emailService.SendEmail(request);
        return Ok();
    }
}
