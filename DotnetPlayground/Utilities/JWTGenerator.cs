using DotnetPlayground.WebApi.Utilities.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharedPocos.Models;
using SharedPocos.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DotnetPlayground.WebApi.Utilities;

public class JWTGenerator : IJWTGenerator
{
    private readonly JwtSettingsOptions _jwtSettingsOptions;

    public JWTGenerator(IOptions<JwtSettingsOptions> jwtSettingsOptions)
    {
        _jwtSettingsOptions = jwtSettingsOptions.Value;
    }

    public string GenerateIdentityJwt(IdentityUser user)
    {
        var request = new TokenGenerationRequest()
        {
            UserId = user.Id,
            Email = user.Email
        };
        return GenerateJwt(request);
    }

    public string GenerateJwt(TokenGenerationRequest request)
    {
        var tokenDescriptor = GetSecurityTokenDescriptor(request);
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);
        return jwtToken;
    }

    private SecurityTokenDescriptor GetSecurityTokenDescriptor(TokenGenerationRequest request) => new()
    {
        Subject = new ClaimsIdentity(GetClaims(request)),
        SigningCredentials = GetSigningCredentials(),
        Issuer = _jwtSettingsOptions.Issuer,
        Audience = _jwtSettingsOptions.Audience,
        Expires = DateTime.UtcNow.AddMinutes(_jwtSettingsOptions.ExpiryMinutes)
    };

    private static List<Claim> GetClaims(TokenGenerationRequest request)
    {
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Sub, request.Email),
            new(JwtRegisteredClaimNames.Email, request.Email),
            new(JwtRegisteredClaimNames.Iat, DateTime.Now.ToUniversalTime().ToString()),
            new("userid", request.UserId),
        };

        if (request.CustomClaims != null)
        {
            foreach (var customClaim in request.CustomClaims)
            {
                claims.Add(new Claim(customClaim.Key, customClaim.Value));
            }
        }

        return claims;
    }

    private SigningCredentials GetSigningCredentials()
    {
        var key = _jwtSettingsOptions.Key;
        var keyBytes = Encoding.UTF8.GetBytes(key);
        var symmetricSecurityKey = new SymmetricSecurityKey(keyBytes);
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);
        return signingCredentials;
    }
}
