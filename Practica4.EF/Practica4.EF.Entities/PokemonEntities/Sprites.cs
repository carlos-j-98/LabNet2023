using Newtonsoft.Json;

namespace Practica4.EF.Entities.PokemonEntities
{
    public class Sprites
    {
        [JsonProperty("front_default")]
        public string FrontDefault { get; set; }

        [JsonProperty("back_default")]
        public string BackDefault { get; set; }
    }
}
