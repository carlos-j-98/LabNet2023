using Newtonsoft.Json;

namespace Practica4.EF.Entities.PokemonEntities
{
    public class StatsInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
