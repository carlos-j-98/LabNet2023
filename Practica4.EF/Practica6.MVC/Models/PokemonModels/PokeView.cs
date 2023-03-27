using Newtonsoft.Json;
using Practica4.EF.Entities.PokemonEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Practica6.MVC.Models.PokemonModels
{
    public class PokeView
    {
        [JsonProperty("results")]
        public List<Pokemon> pokeList { get; set; }
    }
}