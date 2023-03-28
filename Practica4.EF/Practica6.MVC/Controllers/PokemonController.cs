using Practica4.EF.Entities.PokemonEntities;
using Practica4.EF.Logic.LogicBussines.LogicInterface;
using Practica4.EF.Services.ExtensionMethods;
using Practica4.EF.Services.Resources;
using Practica6.MVC.ServicesMVC.ExtensionMethods;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Practica6.MVC.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokemonLogic _pokemonLogic;
        public PokemonController(IPokemonLogic pokeLogic)
        {
            this._pokemonLogic = pokeLogic;
        }
        // GET: Pokemon
        public async Task<ActionResult> Index(int? limit, int? offset)
        {
            if (limit == null)
            {
                limit = int.Parse(ConfigurationManager.AppSettings["DEFAULT_LIMIT"]);
            }
            if (offset == null)
            {
                offset = int.Parse(ConfigurationManager.AppSettings["DEFAULT_OFFSET"]);
            }
            List<Pokemon> pokemons = new List<Pokemon>();
            var pokemonResult = _pokemonLogic.GetPagesPokemon(limit, offset);
            foreach (var pokemon in pokemonResult.Result.pokeList)
            {
                var pokeInfo = _pokemonLogic.GetPokemon(pokemon.Url);
                pokemons.Add(pokeInfo.Result);
            }
            return View(pokemons.ToPokemonView());
        }

        public async Task<ActionResult> Info(string name)
        {
            if (name == null)
            {
                return RedirectToAction("Index", "Error", new { error = Messages.notFoundPokemon.ToJSON() }); ;
            }
            var response = _pokemonLogic.GetPokemonId(name);

            return View(response.Result.ToPokemonView());
        }


    }
}