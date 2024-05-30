using EntityFrameworkCorePlayground.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SharedPocos.Models.Identity;
using System.Text;

namespace DotnetPlayground.WebApi.ExtensionMethods;

public static class AuthenticateAndAuthorize
{
    public static void RegisterAuthentication(this IServiceCollection services, ConfigurationManager config)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = config["jwtSettings:issuer"],
            ValidAudience = config["jwtSettings:audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["jwtSettings:key"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
        };

        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = tokenValidationParameters;
        });

        services.AddSingleton(tokenValidationParameters);

        // Makes sure Identity can be used
        services.AddIdentityCore<IdentityUser>(options =>
        {
            options.SignIn.RequireConfirmedEmail = false;
        })
        .AddEntityFrameworkStores<DummyDbContext>();
    }

    public static void RegisterAuthorizationOptions(this AuthorizationOptions options)
    {
        options.AddPolicy(IdentityData.AdminUserPolicyName, p =>
        {
            p.RequireClaim(IdentityData.AdminUserClaimName, "true");
        });
    }
}
