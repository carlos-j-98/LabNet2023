using Newtonsoft.Json;
using Practica4.EF.Entities.PokemonEntities;
using System.Collections.Generic;

namespace Practica6.MVC.Models.PokemonModels
{
    public class PokeView
    {
        [JsonProperty("results")]
        public List<Pokemon> pokeList { get; set; }
    }
}