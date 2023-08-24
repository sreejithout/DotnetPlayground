using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SharedPocos.Options;

namespace DotnetPlayground.WebApi.Controllers;


[Route("api/v1/[controller]/[action]")]
[ApiController]
public class ExternalApiController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _config;
    private readonly PokemonApiOptions _pokemonApiOptions;

    public ExternalApiController(IHttpClientFactory httpClientFactory, IConfiguration config, IOptions<PokemonApiOptions> pokemonApiOptions)
    {
        _httpClientFactory = httpClientFactory;
        _config = config;
        _pokemonApiOptions = pokemonApiOptions.Value;
    }

    /// <summary>
    /// Get Directly From IConfiguration
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<string> GetDirectlyFromConfig()
    {
        var baseUrl = _config.GetValue<string>("pokemonApi:baseUrl");
        var apiVersion = _config.GetSection("pokemonApi").GetValue<string>("apiV2");
        var apiEndpoint = _config.GetSection("pokemonApi").GetValue<string>("pokemonDittoUrl");

        using var client = _httpClientFactory.CreateClient();
        return await client.GetStringAsync($"{baseUrl}/{apiVersion}/{apiEndpoint}");
    }

    /// <summary>
    /// Get From IOptions
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<string> GetFromOptions()
    {
        var baseUrl = _pokemonApiOptions.BaseUrl;
        var apiVersion = _pokemonApiOptions.ApiV2;
        var apiEndpoint = _pokemonApiOptions.PokemonDittoUrl;

        using var client = _httpClientFactory.CreateClient();
        return await client.GetStringAsync($"{baseUrl}/{apiVersion}/{apiEndpoint}");
    }
}
