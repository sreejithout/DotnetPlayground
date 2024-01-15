using EntityFrameworkCorePlayground.Models;
using Microsoft.AspNetCore.Identity;
using SharedPocos.DTOs;
using SharedPocos.Models;

namespace DotnetPlayground.WebApi.Utilities.Interfaces;

public interface IJWTGenerator
{
    Task<(string, string)> GenerateIdentityJwt(IdentityUser user);
    Task<(string, string)> GenerateJwt(TokenGenerationRequest request);
    Task<(bool, RefreshToken)> VerifyAndGenerateToken(TokenRequest tokenRequest);
}
