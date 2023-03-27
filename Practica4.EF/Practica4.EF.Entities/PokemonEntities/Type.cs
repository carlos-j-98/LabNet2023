using Newtonsoft.Json;

namespace Practica4.EF.Entities.PokemonEntities
{
    public class Type
    {
        [JsonProperty("type")]
        public TypeInfo TypeName { get; set; }
    }
}
