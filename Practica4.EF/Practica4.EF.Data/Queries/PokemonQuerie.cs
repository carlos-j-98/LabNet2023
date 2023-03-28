using Newtonsoft.Json;
using Practica4.EF.Data.Queries.InterfaceQueries;
using Practica4.EF.Entities.PokemonEntities;
using Practica4.EF.Entities.PokemonEntitiesView.PokemonModels;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace Practica4.EF.Data.Queries
{
    public class PokemonQuerie : IPokemonQuerie
    {
        private readonly HttpClient _httpClient;
        public PokemonQuerie()
        {
            _httpClient = new HttpClient();
        }
        public Task<Pokemon> GetPokemonInfo(string url)
        {
            var pokemonResponse = _httpClient.GetAsync(url).Result;
            var pokemonContent = pokemonResponse.Content.ReadAsStringAsync().Result;
            var detailedPokemon = JsonConvert.DeserializeObject<Pokemon>(pokemonContent);
            return Task.FromResult(detailedPokemon);
        }

        public Task<PokeView> GetPokemonPage(int? offset, int? limit)
        {
            var response = _httpClient.GetAsync($"{ConfigurationManager.AppSettings["URL_BASE_POKEMON"]}?limit={limit}&offset={offset}").Result;
            var content = response.Content.ReadAsStringAsync().Result;
            var pokemonResult = JsonConvert.DeserializeObject<PokeView>(content);
            return Task.FromResult(pokemonResult);
        }
        public Task<Pokemon> GetPokemonId(string id)
        {
            var response = _httpClient.GetAsync($"{ConfigurationManager.AppSettings["URL_BASE_POKEMON"]}/{id}/").Result;
            var jsonContent = response.Content.ReadAsStringAsync().Result;
            var pokemon = JsonConvert.DeserializeObject<Pokemon>(jsonContent);
            return Task.FromResult(pokemon);
        }

    }
}
