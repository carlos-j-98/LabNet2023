using Practica4.EF.Entities.PokemonEntities;
using Practica4.EF.Entities.PokemonEntitiesView.PokemonModels;
using System.Threading.Tasks;

namespace Practica4.EF.Data.Queries.InterfaceQueries
{
    public interface IPokemonQuerie
    {
        Task<PokeView> GetPokemonPage(int? offset, int? limit);
        Task<Pokemon> GetPokemonInfo(string url);
        Task<Pokemon> GetPokemonId(string id);
    }
}
