using System.ComponentModel.DataAnnotations;

namespace SharedPocos.Options;

public class PokemonApiOptions
{
    public const string PokemonApi = "pokemonApi";

    [Required]
    public string BaseUrl { get; set; }
    public string ApiV2 { get; set; }
    public string PokemonDittoUrl { get; set; }
}
