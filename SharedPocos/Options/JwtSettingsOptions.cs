using System.ComponentModel.DataAnnotations;

namespace SharedPocos.Options;

public class JwtSettingsOptions
{
    public const string JwtSettings = "jwtSettings";

    [Required]
    public string Issuer { get; set; }

    [Required]
    public string Audience { get; set; }

    [Required]
    public string Key { get; set; }
    public int ExpiryMinutes { get; set; }
}
