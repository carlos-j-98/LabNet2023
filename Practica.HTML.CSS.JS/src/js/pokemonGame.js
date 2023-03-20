const img1 = document.querySelector("#img-1");
const img2 = document.querySelector("#img-2");
const img3 = document.querySelector("#img-3");
const img4 = document.querySelector("#img-4");
const img5 = document.querySelector("#img-5");
const img6 = document.querySelector("#img-6");

let scoreText = document.querySelector("#score-id");
let button = document.querySelector("#buttonGuess");
let buttonRestart = document.querySelector("#restartButton");
let inputGuess = document.querySelector("#inputGuess");
const containerMsg = document.getElementById("incorrectOption");
let lastGuess;
let score;
let highScore;
let statusGame = "";

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

function loadImgPokemons(idPokemon, posImg, images) {
  fetch(urlBase + idPokemon)
    .then((response) => response.json())
    .then((data) => {
      let imageSources = data.sprites.front_default;
      images[posImg].src = imageSources;
      images[posImg].alt = data.name;
      if ("img-" + (posImg + 1) == localStorage.getItem("guessWinner")) {
        localStorage.setItem("pokeUrl", JSON.stringify(pokeUrl));
        localStorage.setItem("type", data.types[0].type.name);
        localStorage.setItem("idPokemon", data.id);
        localStorage.setItem("namePokemon", data.name);
        localStorage.setItem("posPokemon", posImg + 1);
      }
    })
    .catch((error) => {});
}

function pokemonGen() {
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
      genPoke = "Séptima";
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

const images = [img1, img2, img3, img4, img5, img6];
images.forEach((image) => {
  image.addEventListener("click", () => {
    const clickedNumber = image.getAttribute("id");
    principalRun(clickedNumber);
  });
});
button.addEventListener("click", () => {
  principalRun("img-" + inputGuess.value);
});
buttonRestart.addEventListener("click", () => {
  defaultValues();
});
function defaultValues() {
  score = 5;
  highScore = document.querySelector("#highScore-id");
  scoreText = document.querySelector("#score-id");
  statusGame = "";
  if (lastGuess != undefined) {
    document.getElementById(
      localStorage.getItem("guessWinner")
    ).style.backgroundColor = "#FFFFFF";
  }
  initGame();
}

defaultValues();

function initGame() {
  initImg();
  initScores();
  selectWinner();
  initHint();
  changeWin("Reiniciar");
}

function principalRun(id) {
  if (statusGame != "fin") {
    if (id === localStorage.getItem("guessWinner")) {
      changeWin("Ganaste");
    } else {
      downScore();
      updateHints();
      incorrectOption();
    }
  }
}

function selectWinner() {
  let randomNumber = Math.floor(Math.random() * 6 + 1);
  while (randomNumber === 0) {
    let randomNumber = Math.floor(Math.random() * 6 + 1);
  }
  localStorage.setItem("guessWinner", "img-" + randomNumber);
}

function changeWin(status) {
  let imgAsh = document.getElementById("ashImg");
  let resultText = document.getElementById("resultTextGuess");
  let pokeSelect = localStorage.getItem("namePokemon");
  let posPokemon = localStorage.getItem("posPokemon");
  if (status === "Ganaste") {
    imgAsh.src = "../assets/img/ashFeliz.jpg";
    document.body.style.backgroundColor = "#008000";
    document.getElementById(
      localStorage.getItem("guessWinner")
    ).style.backgroundColor = "green";
    lastGuess = localStorage.getItem("guessWinner");
    resultText.textContent =
      "¡Pokemon correcto! ¡Excelente elección, entrenador! Ese es un Pokemon increíblemente fuerte y valiente. El pokemon estaba en la posición nº " +
      posPokemon + " y era " + pokeSelect.toUpperCase();
    statusGame = "fin";
    removeIncorrectOption();
    updateHighScore();
  } else if (status === "Perdiste") {
    document.body.style.backgroundColor = "#FF0000";
    document.getElementById(
      localStorage.getItem("guessWinner")
    ).style.backgroundColor = "red";
    imgAsh.src = "../assets/img/ashTriste.jpg";
    lastGuess = localStorage.getItem("guessWinner");
    resultText.textContent =
      "¡Pokemon incorrecto! Oh no, ese no es el Pokemon correcto. Pero no te preocupes, seguro encontrarás el pokemon que está pensando Ash para la próxima. El pokemon estaba en la posición nº "+ posPokemon + " y era " +
      pokeSelect.toUpperCase();
    statusGame = "fin";
    removeIncorrectOption();
  } else if (status === "Reiniciar") {
    imgAsh.src = "../assets/img/Ash.png";
    document.body.style.backgroundColor = "#F0F0F0";
    resultText.textContent =
      "Ash eligio uno de estos pokemon del 1 al 6.\n ¿Podés adivinar cual es de estos es?";
  }
}

function initImg() {
  for (let index = 0; index < 6; index++) {
    const randomPoke = Math.floor(Math.random() * 1008) + 1;
    loadImgPokemons(randomPoke, index, images);
  }
}

function initHint() {
  const divHint1 = document.getElementById("div-hint1");
  const divHint2 = document.getElementById("div-hint2");
  divHint1.innerHTML =
    '<h1>El pokemon es de tipo: <br><span id="text-hint1">Se desbloqueará cuando tu puntuación sea 3 o menor</span></h1>';
  divHint2.innerHTML =
    '<h1>La generación del pokemon es: <br> <span id="text-hint2"> Se desbloqueará cuando tu puntuación sea 1</span></h1>';
}

function setHintImg(type, pokeUrl) {
  if (score === 3) {
    for (let key in pokeUrl) {
      if (key == type) {
        var img = document.createElement("img");
        img.src = pokeUrl[key];
        img.alt = "imagen de pista";
        img.id = "img-hin1";
        var div = document.getElementById("div-hint1");
        div.appendChild(img);
        var text = document.getElementById("text-hint1");
        text.remove();
      }
    }
  }
}

function setHintText() {
  if (score === 1) {
    var hintText = document.querySelector("#text-hint2");
    hintText.textContent = pokemonGen();
  }
}

function updateHints() {
  let type = localStorage.getItem("type");
  let url = JSON.parse(localStorage.getItem("pokeUrl"));
  setHintImg(type, url);
  setHintText();
}
function incorrectOption() {
  const msgDiv = document.createElement("div");
  msgDiv.textContent = "Pokémon incorrecto, inténtalo de nuevo.";
  msgDiv.classList.add("message");
  msgDiv.classList.add("incorrecto");
  msgDiv.id = "msgIncorrectOption";
  localStorage.setItem("incorrectOption", msgDiv.id);
  containerMsg.appendChild(msgDiv);
  setTimeout(() => {
    removeIncorrectOption();
  }, 3000);
}

function removeIncorrectOption() {
  var remove = document.getElementById(localStorage.getItem("incorrectOption"));
  if (remove != null) {
    remove.remove();
  }
}

function initScores() {
  scoreText.textContent = score;
  if (localStorage.getItem("highScore") === null) {
    highScore.textContent = 0;
    localStorage.setItem("highScore", 0);
  } else {
    highScore.textContent = localStorage.getItem("highScore");
  }
}

function downScore() {
  if (score > 0) {
    score--;
    scoreText.textContent = score;
  }
  if (score === 0) {
    changeWin("Perdiste");
  }
}

function updateHighScore() {
  if (localStorage.getItem("highScore") < score) {
    highScore.textContent = score;
    localStorage.setItem("highScore", score);
  }
}
