using Microsoft.AspNetCore.Identity;
using SharedPocos.Models;

namespace DotnetPlayground.WebApi.Utilities.Interfaces;

public interface IJWTGenerator
{
    string GenerateIdentityJwt(IdentityUser user);
    string GenerateJwt(TokenGenerationRequest request);
}
