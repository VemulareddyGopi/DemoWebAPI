using System.ComponentModel.DataAnnotations;

namespace SirIthara.Api.Models;

public class AdoUser
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public bool Status { get; set; }
    public DateTime DOB { get; set; }
}
