using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.EF.Entities.PokemonEntities
{
    public class StatsInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
