using Newtonsoft.Json;

namespace Practica4.EF.Entities.PokemonEntities
{
    public class TypeInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
