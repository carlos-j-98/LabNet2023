using Practica4.EF.Data.Queries.InterfaceQueries;
using Practica4.EF.Entities.PokemonEntities;
using Practica4.EF.Entities.PokemonEntitiesView.PokemonModels;
using Practica4.EF.Logic.LogicBussines.LogicInterface;
using System.Threading.Tasks;

namespace Practica4.EF.Logic.LogicBussines
{
    public class PokemonLogic : IPokemonLogic
    {
        private readonly IPokemonQuerie _pokemonQuerie;
        public PokemonLogic(IPokemonQuerie pokemonQuerie)
        {
            _pokemonQuerie = pokemonQuerie;
        }
        public Task<PokeView> GetPagesPokemon(int? limit, int? offset)
        {
            return _pokemonQuerie.GetPokemonPage(offset, limit);
        }
        public Task<Pokemon> GetPokemon(string url)
        {
            return _pokemonQuerie.GetPokemonInfo(url);
        }

        public Task<Pokemon> GetPokemonId(string id)
        {
            return _pokemonQuerie.GetPokemonId(id);
        }
    }
}
