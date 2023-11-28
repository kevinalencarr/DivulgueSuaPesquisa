using System.ComponentModel.DataAnnotations;

namespace DivulgueSuaPesquisa.Models;

public class EmailDto
{
    public string? Subject { get; set; }
    
    [Required]
    public string? Name { get; set; }
    
    public string? Lab { get; set; }
    
    [Required]
    public string? Dept { get; set; }
    
    [Required]
    public string? ResearchTitle { get; set; }
    
    [Required]
    public string? ResearchSummary { get; set; }
    
    [Required]
    public string? PublicationLink { get; set; }
    
    [Required]
    public string? ContactPhone { get; set; }
    
    [Required]
    [EmailAddress(ErrorMessage = "O formato do e-mail não é válido.")]
    public string? ContactEmail { get; set; }
}
