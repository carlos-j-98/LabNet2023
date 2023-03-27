using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.EF.Entities.PokemonEntities
{
    public class Stats
    {
        [JsonProperty("base_stat")]
        public string BaseStat { get; set; }
        [JsonProperty("effort")]
        public string Effort { get; set; }
        [JsonProperty("stat")]
        public StatsInfo Stat { get; set; }
    }
}
