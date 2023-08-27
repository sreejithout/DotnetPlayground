using System.ComponentModel.DataAnnotations;

namespace SharedPocos.Options;

public class WeatherApiOptions
{
    public const string WeatherApi = "weatherApi";

    [Required]
    public string? ApiBaseUrl { get; set; }
    public string? ApiKey { get; set; }
    public string? CurrentWeatherUrl { get; set; }
    public string? ForecastUrl { get; set; }
}
