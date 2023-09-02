using SharedPocos.Models;

namespace DotnetPlayground.WebApi.Utilities.Interfaces;

public interface IJWTGenerator
{
    string GenerateJwt(TokenGenerationRequest request);
}
