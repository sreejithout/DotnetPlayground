using DotnetPlayground.WebApi.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DotnetPlayground.WebApi.Controllers;

[Route("api/v1/[controller]/[action]")]
[ApiController]
[SampleActionFilter("FilterController")]
public class FilterController : ControllerBase
{
    [HttpGet]
    public string GetWithoutFilter()
    {
        return "Hello Filter";
    }

    [HttpGet]
    [SampleActionFilter("GetWithFilter Action")]
    public string GetWithFilter()
    {
        return "Hello Filter";
    }

    [HttpGet]
    [SampleAsyncActionFilter("GetWithAsyncFilter Action")]
    public string GetWithAsyncFilter()
    {
        return "Hello Async Filter";
    }
}
