using Practica4.EF.Entities.PokemonEntities;
using Practica4.EF.Entities.PokemonEntitiesView.PokemonModels;
using System.Threading.Tasks;

namespace Practica4.EF.Logic.LogicBussines.LogicInterface
{
    public interface IPokemonLogic
    {
        Task<PokeView> GetPagesPokemon(int? limit, int? offset);
        Task<Pokemon> GetPokemon(string url);
        Task<Pokemon> GetPokemonId(string id);
    }
}
