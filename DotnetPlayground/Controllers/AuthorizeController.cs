using DotnetPlayground.WebApi.Utilities.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedPocos.Models;
using SharedPocos.Models.Identity;

namespace DotnetPlayground.WebApi.Controllers;

[Authorize]
[Route("api/v1/[controller]/[action]")]
[ApiController]
public class AuthorizeController : ControllerBase
{
    private readonly IJWTGenerator _jwtGenerator;

    public AuthorizeController(IJWTGenerator jwtGenerator)
    {
        _jwtGenerator = jwtGenerator;
    }

    [AllowAnonymous]
    [HttpGet]
    public ActionResult GetAnonymously()
    {
        return Ok("it's a simple endpoint without authorization");
    }

    [HttpGet]
    public ActionResult GetAfterSimpleAuthorize()
    {
        return Ok("it's a simple authorize endpoint");
    }

    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    [HttpGet]
    public ActionResult GetUsingRBAC()
    {
        return Ok("it's a simple endpoint with Role Based Access Control");
    }

    [AllowAnonymous]
    [HttpPost]
    public ActionResult<string> SampleAuthenticationEndpoint(TokenGenerationRequest request)
    {
        return _jwtGenerator.GenerateJwt(request);
    }
}
