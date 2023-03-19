let pokeUrl = {
  water:
    "https://static.wikia.nocookie.net/pokemongo_es_gamepedia/images/d/d3/Icon_Agua.png",
  steel:
    "https://static.wikia.nocookie.net/pokemongo_es_gamepedia/images/b/bc/Icon_Acero.png",
  bug: "https://static.wikia.nocookie.net/pokemongo_es_gamepedia/images/7/7e/Icon_Bicho.png",
  dragon:
    "https://static.wikia.nocookie.net/pokemongo_es_gamepedia/images/9/96/Icon_Drag%C3%B3n.png",
  electric:
    "https://static.wikia.nocookie.net/pokemongo_es_gamepedia/images/3/33/Icon_El%C3%A9ctrico.png",
  ghost:
    "https://static.wikia.nocookie.net/pokemongo_es_gamepedia/images/9/9a/Icon_Fantasma.png",
  fire: "https://static.wikia.nocookie.net/pokemongo_es_gamepedia/images/4/44/Icon_Fuego.png",
  hada: "https://static.wikia.nocookie.net/pokemongo_es_gamepedia/images/6/60/Icon_Hada.png",
  ice: "https://static.wikia.nocookie.net/pokemongo_es_gamepedia/images/2/22/Icon_Hielo.png",
  fighting:
    "https://static.wikia.nocookie.net/pokemongo_es_gamepedia/images/4/4c/Icon_Lucha.png",
  normal:
    "https://static.wikia.nocookie.net/pokemongo_es_gamepedia/images/4/43/Icon_Normal.png",
  grass:
    "https://static.wikia.nocookie.net/pokemongo_es_gamepedia/images/7/7f/Icon_Planta.png",
  psychic:
    "https://static.wikia.nocookie.net/pokemongo_es_gamepedia/images/c/c0/Icon_Ps%C3%ADquico.png",
  rock: "https://static.wikia.nocookie.net/pokemongo_es_gamepedia/images/1/12/Icon_Roca.png",
  dark: "https://static.wikia.nocookie.net/pokemongo_es_gamepedia/images/a/a4/Icon_Siniestro.png",
  ground:
    "https://static.wikia.nocookie.net/pokemongo_es_gamepedia/images/8/8d/Icon_Tierra.png",
  poison:
    "https://static.wikia.nocookie.net/pokemongo_es_gamepedia/images/3/3e/Icon_Veneno.png",
  fly: "https://static.wikia.nocookie.net/pokemongo_es_gamepedia/images/d/d3/Icon_Volador.png",
};
let urlBase = "https://pokeapi.co/api/v2/pokemon/";

export function loadImgPokemons(idPokemon, posImg, images) {
  fetch(urlBase + idPokemon)
    .then((response) => response.json())
    .then((data) => {
      let imageSources = data.sprites.front_default;
      images[posImg].src = imageSources;
      if ("img-"+ (posImg+1) == localStorage.getItem("guessWinner")) {
        localStorage.setItem("pokeUrl",JSON.stringify(pokeUrl));
        localStorage.setItem("type",data.types[0].type.name)
        localStorage.setItem("idPokemon", data.id);
      }
    })
    .catch((error) => {});
}

export function pokemonGen() {
  let pokeId = parseInt(localStorage.getItem("idPokemon"));
  let genPoke;
  switch (true) {
    case pokeId <= 151:
      genPoke = "Primera";
      break;
    case pokeId <= 251:
      genPoke = "Segunda";
      break;
    case pokeId <= 386:
      genPoke = "Tercera";
      break;
    case pokeId <= 493:
      genPoke = "Cuarta";
      break;
    case pokeId <= 649:
      genPoke = "Quinta";
      break;
    case pokeId <= 721:
      genPoke = "Sexta";
      break;
    case pokeId <= 809:
      genPoke = "Septima";
      break;
    case pokeId <= 902:
      genPoke = "Octava";
      break;
    case pokeId <= 1008:
      genPoke = "Novena";
      break;
  }
  return genPoke;
}