using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SharedPocos.Options;

namespace DotnetPlayground.WebApi.Controllers;

public class WeatherApiController : ControllerBase
{
    private readonly WeatherApiOptions _weatherApiOptions;
    private readonly IHttpClientFactory _httpClientFactory;

    public WeatherApiController(IOptions<WeatherApiOptions> weatherApiOptions, IHttpClientFactory httpClientFactory)
    {
        _weatherApiOptions = weatherApiOptions.Value;
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet("{city}")]
    public async Task<string> Get([FromRoute] string city)
    {
        var client = _httpClientFactory.CreateClient("weatherApi");
        var url = $"{_weatherApiOptions.CurrentWeatherUrl}?q={city}&key={_weatherApiOptions.ApiKey}";
        var response = await client.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }
}
