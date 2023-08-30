using DotnetPlayground.WebApi.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace DotnetPlayground.WebApi.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class ErrorHandlingController : ControllerBase
{
    private readonly ILogger<ErrorHandlingController> _logger;

    public ErrorHandlingController(ILogger<ErrorHandlingController> logger)
    {
        _logger = logger;
    }

    [HttpGet("{name}")]
    public ActionResult<string> GetTryCatch(string name)
    {
        try
        {
            if (name is "sreejith")
            {
                throw new Exception("Exception from try catch");
            }
            return Ok("not sreejith");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{name}")]
    public ActionResult<string> GetFromMiddleware(string name)
    {
        if (name is "sreejith")
        {
            throw new Exception("Exception from try catch");
        }
        return Ok("not sreejith");
    }

    [HttpGet("{name}")]
    public ActionResult<string> GetFromMiddlewareWithCustomNotFoundException(string name)
    {
        if (name is "sreejith")
        {
            throw new SampleNotFoundException("Exception from try catch");
        }
        return Ok("not sreejith");
    }

    [HttpGet("{name}")]
    public ActionResult<string> GetFromMiddlewareWithCustomValidationException(string name)
    {
        if (name is "sreejith")
        {
            throw new SampleValidationException("Exception from try catch");
        }
        return Ok("not sreejith");
    }
}
