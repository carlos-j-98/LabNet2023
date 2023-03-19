import { loadImgPokemons, pokemonGen } from "./getDataPokemon.js";

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
let score;
let highScore;
let statusGame = "";

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
  score = 6;
  highScore = document.querySelector("#highScore-id");
  scoreText = document.querySelector("#score-id");
  statusGame = "";
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
  if (status === "Ganaste") {
    imgAsh.src = "../assets/img/ashFeliz.jpg";
    document.body.style.backgroundColor = "#008000";
    resultText.textContent =
      "¡Pokemon correcto! ¡Excelente elección, entrenador! Ese es un Pokemon increíblemente fuerte y valiente.";
    statusGame = "fin";
    removeIncorrectOption();
    updateHighScore();
  } else if (status === "Perdiste") {
    document.body.style.backgroundColor = "#FF0000";
    imgAsh.src = "../assets/img/ashTriste.jpg";
    resultText.textContent =
      "¡Pokemon incorrecto! Oh no, ese no es el Pokemon correcto. Pero no te preocupes, seguro encontrarás el pokemon que esta pensando Ash para la proxima";
    statusGame = "fin";
    removeIncorrectOption();
  } else if (status === "Reiniciar") {
    imgAsh.src = "../assets/img/Ash.png";
    document.body.style.backgroundColor = "#F0F0F0";
    resultText.textContent =
      "La PC de Ash esta llena de Pokemon y esta formando un nuevo equipo. \n Tiene estas 6 opciones ¿Cual crees que eligio?";
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
    '<h1>El pokemon es de tipo: <br><span id="text-hint1">Se desbloqueara cuando tu puntuacion sea 4</span></h1>';
  divHint2.innerHTML =
    '<h1>La generacion del pokemon es: <br> <span id="text-hint2"> Se desbloqueara cuando tu puntuacion sea 2</span></h1>';
}

function setHintImg(type, pokeUrl) {
  if (score === 4) {
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
  if (score === 2) {
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
  msgDiv.textContent = "Pokemon incorrecto, intente nuevamente";
  msgDiv.classList.add("message");
  msgDiv.classList.add("incorrecto");
  msgDiv.id = "msgIncorrectOption";
  localStorage.setItem("incorrectOption",msgDiv.id);
  containerMsg.appendChild(msgDiv);
  setTimeout(() => {
    removeIncorrectOption();
  }, 3000);
}

function removeIncorrectOption(){
  var remove = document.getElementById(localStorage.getItem("incorrectOption"));
    if(remove != null){
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
