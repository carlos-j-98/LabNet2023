using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Practica4.EF.Entities.PokemonEntities;
using Practica4.EF.Services.ExtensionMethods;
using Practica6.MVC.Models;
using Practica6.MVC.Models.PokemonModels;
using Practica6.MVC.ServicesMVC.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Practica6.MVC.Controllers
{
    public class PokemonController : Controller
    {
        private readonly HttpClient _httpClient;
        public PokemonController()
        {
            _httpClient = new HttpClient();
        }
        // GET: Pokemon
        public async Task<ActionResult> Index(int? limit,int? offset)
        {
            if(limit == null) 
            {
                limit = int.Parse(ConfigurationManager.AppSettings["defaultLimit"]);
            }
            if(offset == null) 
            {
                offset = int.Parse(ConfigurationManager.AppSettings["defaultOffset"]);
            }

            List<Pokemon> pokemons = new List<Pokemon>();
            var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon?limit={limit}&offset={offset}");
            var content = await response.Content.ReadAsStringAsync();
            var pokemonResult = JsonConvert.DeserializeObject<PokeView>(content);
            foreach (var pokemon in pokemonResult.pokeList)
            {
                // Realiza una solicitud GET para obtener más detalles sobre el Pokemon
                var pokemonResponse = await _httpClient.GetAsync(pokemon.Url);

                if (pokemonResponse.IsSuccessStatusCode)
                {
                    var pokemonContent = await pokemonResponse.Content.ReadAsStringAsync();
                    var detailedPokemon = JsonConvert.DeserializeObject<Pokemon>(pokemonContent);
                    pokemons.Add(detailedPokemon);
                }
            }
            return View(pokemons.ToPokemonView());
        }

        public async Task<ActionResult> Info(string name)
        {
            if(name == null) 
            {
                return RedirectToAction("Index","Error", new { error = ConfigurationManager.AppSettings["notFoundPokemon"].ToJSON() });
            }
            var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{name}/");

            if (!response.IsSuccessStatusCode)
            {
                return HttpNotFound();
            }

            var jsonContent = await response.Content.ReadAsStringAsync();
            var pokemon = JsonConvert.DeserializeObject<Pokemon>(jsonContent);

            return View(pokemon.ToPokemonView());
        }


    }
}