using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica4.EF.Entities.PokemonEntities
{
    public class Type
    {
        [JsonProperty("type")]
        public TypeInfo TypeName { get; set; }
    }
}
