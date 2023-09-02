namespace SharedPocos.Models;

public class TokenGenerationRequest
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public List<CustomClaim> CustomClaims { get; set; }
}
