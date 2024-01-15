using DotnetPlayground.WebApi.Utilities.Interfaces;
using EntityFrameworkCorePlayground.Data;
using EntityFrameworkCorePlayground.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharedPocos.DTOs;
using SharedPocos.Models;
using SharedPocos.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DotnetPlayground.WebApi.Utilities;

public class JWTGenerator : IJWTGenerator
{
    private readonly JwtSettingsOptions _jwtSettingsOptions;
    private readonly DummyDbContext _dbContext;
    private readonly TokenValidationParameters _tokenValidationParameters;

    public JWTGenerator(IOptions<JwtSettingsOptions> jwtSettingsOptions, DummyDbContext dbContext, TokenValidationParameters tokenValidationParameters)
    {
        _jwtSettingsOptions = jwtSettingsOptions.Value;
        _dbContext = dbContext;
        _tokenValidationParameters = tokenValidationParameters;
    }

    public async Task<(string, string)> GenerateIdentityJwt(IdentityUser user)
    {
        var request = new TokenGenerationRequest()
        {
            UserId = user.Id,
            Email = user.Email
        };
        return await GenerateJwt(request);
    }

    public async Task<(string, string)> GenerateJwt(TokenGenerationRequest request)
    {
        var tokenDescriptor = GetSecurityTokenDescriptor(request);
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwtToken = tokenHandler.WriteToken(token);

        var refreshToken = new RefreshToken()
        {
            JwtId = token.Id,
            Token = RandomStringGenerator(56),
            AddedDate = DateTime.UtcNow,
            ExpiryDate = DateTime.UtcNow.AddMonths(6),
            IsRevoked = false,
            IsUsed = false,
            UserId = request.UserId
        };

        await _dbContext.RefreshTokens.AddAsync(refreshToken);
        await _dbContext.SaveChangesAsync();
        return (jwtToken, refreshToken.Token);
    }

    public async Task<(bool, RefreshToken)> VerifyAndGenerateToken(TokenRequest tokenRequest)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        _tokenValidationParameters.ValidateLifetime = false;
        var tokenInVerification = tokenHandler.ValidateToken(tokenRequest.Token, _tokenValidationParameters, out var validatedToken);

        if (validatedToken is JwtSecurityToken jwtSecurityToken)
        {
            var result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha512Signature, StringComparison.InvariantCultureIgnoreCase);

            if (!result)
            {
                // 
                return (false, new RefreshToken());
            }
            var utcExpiryDate = long.Parse(tokenInVerification.Claims.FirstOrDefault(x => x.Type is JwtRegisteredClaimNames.Exp).Value);

            var expiryDate = UnixTimeStampToDateTime(utcExpiryDate);

            if (expiryDate > DateTime.Now)
            {
                // Expired Token
                return (false, new RefreshToken());
            }

            var storedToken = await _dbContext.RefreshTokens.FirstOrDefaultAsync(x => x.Token == tokenRequest.Token);

            if (storedToken == null)
            {
                // Invalid Token
                return (false, new RefreshToken());
            }

            storedToken.IsUsed = true;
            _dbContext.RefreshTokens.Update(storedToken);
            await _dbContext.SaveChangesAsync();
            return (true, storedToken);
        }
        return (false, new RefreshToken());
    }

    private DateTime UnixTimeStampToDateTime(long unixTimeStamp)
    {
        var dateTimeVal = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        dateTimeVal = dateTimeVal.AddSeconds(unixTimeStamp).ToUniversalTime();
        return dateTimeVal;
    }

    private string RandomStringGenerator(int length)
    {
        var random = new Random();
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz_!@#$%&";
        return new string(Enumerable.Repeat(chars, length).Select(x => x[random.Next(x.Length)]).ToArray());
    }

    private SecurityTokenDescriptor GetSecurityTokenDescriptor(TokenGenerationRequest request) => new()
    {
        Subject = new ClaimsIdentity(GetClaims(request)),
        SigningCredentials = GetSigningCredentials(),
        Issuer = _jwtSettingsOptions.Issuer,
        Audience = _jwtSettingsOptions.Audience,
        Expires = DateTime.UtcNow.Add(_jwtSettingsOptions.ExpiryTimeSpan)
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
