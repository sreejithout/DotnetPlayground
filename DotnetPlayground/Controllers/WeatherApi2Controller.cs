using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;
using SharedPocos.Options;

namespace DotnetPlayground.WebApi.Controllers;

[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
public class WeatherApi2Controller : ControllerBase
{
    private readonly WeatherApiOptions _weatherApiOptions;
    private readonly IHttpClientFactory _httpClientFactory;

    public WeatherApi2Controller(IOptions<WeatherApiOptions> weatherApiOptions, IHttpClientFactory httpClientFactory)
    {
        _weatherApiOptions = weatherApiOptions.Value;
        _httpClientFactory = httpClientFactory;
    }

    // Apply rate limiting to this Endpoint
    [EnableRateLimiting("fixed")]
    [HttpGet("GetCurrentWeatherDetails/{city}")]
    public async Task<string> GetCurrentWeatherDetails([FromRoute] string city)
    {
        var client = _httpClientFactory.CreateClient("weatherApi");
        var url = $"{_weatherApiOptions.CurrentWeatherUrl}?q={city}&key={_weatherApiOptions.ApiKey}";
        var response = await client.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }
}
