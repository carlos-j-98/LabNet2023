using Newtonsoft.Json;
using System.Collections.Generic;

namespace Practica4.EF.Entities.PokemonEntities
{
    public class Pokemon
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("sprites")]
        public Sprites Sprites { get; set; }
        [JsonProperty("types")]
        public List<Type> Types { get; set; }
        [JsonProperty("weight")]
        public string Weight { get; set; }
        [JsonProperty("height")]
        public string Height { get; set; }
        [JsonProperty("base_experience")]
        public string BaseExperience { get; set; }
        [JsonProperty("stats")]
        public List<Stats> Stats { get; set; }

    }
}
