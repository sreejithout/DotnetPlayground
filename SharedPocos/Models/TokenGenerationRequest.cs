namespace SharedPocos.Models;

public class TokenGenerationRequest
{
    public string UserId { get; set; }
    public string Email { get; set; }
    public List<CustomClaim> CustomClaims { get; set; }
}
