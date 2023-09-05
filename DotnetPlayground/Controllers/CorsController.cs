using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace DotnetPlayground.WebApi.Controllers;

[Route("api/v1/[controller]/[action]")]
[ApiController]
[EnableCors] // If we don't specify any name here, it will apply default policy.
public class CorsController: ControllerBase
{
    [HttpGet]
    [EnableCors("sampleNamedPolicy")]
    public string GetWithNamedCors()
    {
        return "Cors working";
    }

    [HttpGet]
    [DisableCors]
    public string GetWithDisabledCors()
    {
        return "Withoug any CORS";
    }
}
