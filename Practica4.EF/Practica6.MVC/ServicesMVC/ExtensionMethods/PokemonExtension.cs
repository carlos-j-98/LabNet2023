using Practica4.EF.Entities.PokemonEntities;
using Practica6.MVC.Models.PokemonModels;
using System.Collections.Generic;
using System.Linq;

namespace Practica6.MVC.ServicesMVC.ExtensionMethods
{
    public static class PokemonExtension
    {
        public static List<PokemonView> ToPokemonView(this List<Pokemon> pokeList)
        {
            List<PokemonView> pokemonViewList = pokeList.Select(pokemon =>
            {
                var typeOne = pokemon.Types.Select(x => x.TypeName.Name).First();
                var typeTwo = pokemon.Types.Where(x => x.TypeName.Name != typeOne).Select(x => x.TypeName.Name).FirstOrDefault();

                return new PokemonView
                {
                    Id = pokemon.Id,
                    Name = pokemon.Name,
                    SpriteFront = pokemon.Sprites.FrontDefault,
                    SpriteBack = pokemon.Sprites.BackDefault,
                    TypeOne = typeOne,
                    TypeTwo = typeTwo,
                    Weight = pokemon.Weight,
                    Height = pokemon.Height,
                    HP = pokemon.Stats.Where(s => s.Stat.Name.ToLower() == "hp").Select(s => s.BaseStat).FirstOrDefault(),
                    Attack = pokemon.Stats.Where(s => s.Stat.Name.ToLower() == "attack").Select(s => s.BaseStat).FirstOrDefault(),
                    Speed = pokemon.Stats.Where(s => s.Stat.Name.ToLower() == "speed").Select(s => s.BaseStat).FirstOrDefault(),
                    SpecialAttack = pokemon.Stats.Where(s => s.Stat.Name.ToLower() == "special-attack").Select(s => s.BaseStat).FirstOrDefault(),
                    SpecialDefense = pokemon.Stats.Where(s => s.Stat.Name.ToLower() == "special-defense").Select(s => s.BaseStat).FirstOrDefault(),
                    Defense = pokemon.Stats.Where(s => s.Stat.Name.ToLower() == "defense").Select(s => s.BaseStat).FirstOrDefault()
                };
            }).ToList();
            return pokemonViewList;
        }
        public static PokemonView ToPokemonView(this Pokemon pokemon)
        {
            var typeOne = pokemon.Types.Select(x => x.TypeName.Name).First();
            var typeTwo = pokemon.Types.Where(x => x.TypeName.Name != typeOne).Select(x => x.TypeName.Name).FirstOrDefault();

            return new PokemonView
            {
                Id = pokemon.Id,
                Name = pokemon.Name,
                SpriteFront = pokemon.Sprites.FrontDefault,
                SpriteBack = pokemon.Sprites.BackDefault,
                TypeOne = typeOne,
                TypeTwo = typeTwo,
                Weight = pokemon.Weight,
                Height = pokemon.Height,
                HP = pokemon.Stats.Where(s => s.Stat.Name.ToLower() == "hp").Select(s => s.BaseStat).FirstOrDefault(),
                Attack = pokemon.Stats.Where(s => s.Stat.Name.ToLower() == "attack").Select(s => s.BaseStat).FirstOrDefault(),
                Speed = pokemon.Stats.Where(s => s.Stat.Name.ToLower() == "speed").Select(s => s.BaseStat).FirstOrDefault(),
                SpecialAttack = pokemon.Stats.Where(s => s.Stat.Name.ToLower() == "special-attack").Select(s => s.BaseStat).FirstOrDefault(),
                SpecialDefense = pokemon.Stats.Where(s => s.Stat.Name.ToLower() == "special-defense").Select(s => s.BaseStat).FirstOrDefault(),
                Defense = pokemon.Stats.Where(s => s.Stat.Name.ToLower() == "defense").Select(s => s.BaseStat).FirstOrDefault()
            };
        }
    }
}