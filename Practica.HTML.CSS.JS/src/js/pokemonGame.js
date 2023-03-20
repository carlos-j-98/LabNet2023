let scoreText = document.querySelector("#score-id");
const button = document.querySelector("#buttonGuess");
const buttonRestart = document.querySelector("#restartButton");
const inputGuess = document.querySelector("#inputGuess");
const containerMsg = document.getElementById("incorrectOption");

let lastGuess;
let score;
let highScore;
let images = [];

let statusGame = "";
let maxScore = 5;
let cantBox = 6;
let firstHint = 3;
let secondHint = 1;
let urlBase = "https://pokeapi.co/api/v2/pokemon/";

button.addEventListener("click", () => {
  principalRun("img-" + inputGuess.value);
});
buttonRestart.addEventListener("click", () => {
  defaultValues();
});

defaultValues();

function defaultValues() {
  score = maxScore;
  highScore = document.querySelector("#highScore-id");
  scoreText = document.querySelector("#score-id");
  statusGame = "";
  if (lastGuess != undefined) {
    document.getElementById(
      localStorage.getItem("guessWinner")
    ).style.backgroundColor = "#FFFFFF";
  }
  removeBox();
  addBox();
  chargeImgId();
  initGame();
}

function addBox() {
  let gridBox = document.getElementById("gridBox");
  for (let index = 0; index < cantBox; index++) {
    const newBox = document.createElement("div");
    newBox.classList.add("box");
    newBox.id = "box-"+index;

    const newImage = document.createElement("img");
    newImage.setAttribute("id", "img-"+(index+1));
    newBox.appendChild(newImage);

    const newText = document.createElement("div");
    newText.classList.add("textImg");
    newText.innerHTML = (index+1);
    newBox.appendChild(newText);

    gridBox.appendChild(newBox);
  }
}

function chargeImgId() {
  for (let index = 0; index < cantBox; index++) {
    id = "#img-" + (index + 1);
    imgId = document.querySelector(id);
    images[index] = imgId;
  }
}

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
  let randomNumber = Math.floor(Math.random() * cantBox + 1);
  while (randomNumber === 0) {
    let randomNumber = Math.floor(Math.random() * cantBox + 1);
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
    document.getElementById(localStorage.getItem("guessWinner")).style.backgroundColor = "green";
    lastGuess = localStorage.getItem("guessWinner");
    resultText.textContent = "¡Numero correcto!. El numero era " + posPokemon + " y pokemon era " + pokeSelect.toUpperCase();
    statusGame = "fin";
    removeIncorrectOption();
    updateHighScore();
  } else if (status === "Perdiste") {
    document.body.style.backgroundColor = "#FF0000";
    document.getElementById(localStorage.getItem("guessWinner")).style.backgroundColor = "red";
    imgAsh.src = "../assets/img/ashTriste.jpg";
    lastGuess = localStorage.getItem("guessWinner");
    resultText.textContent =
      "¡Numero incorrecto! Oh no, ese no es el numero correcto. Pero no te preocupes, seguro encontrarás el numero que está pensando Ash para la próxima. El numero era " + posPokemon + " y el pokemon es " + pokeSelect.toUpperCase();
    statusGame = "fin";
    removeIncorrectOption();
  } else if (status === "Reiniciar") {
    imgAsh.src = "../assets/img/Ash.png";
    document.body.style.backgroundColor = "#F0F0F0";
    resultText.textContent = "Ash eligio un numero del 1 al 6 y coincide con el lugar de uno de estos pokemon.\n ¿Podés adivinar cual es de estos es?";
  }
}

function initImg() {
  for (let index = 0; index < cantBox; index++) {
    const randomPoke = Math.floor(Math.random() * 1008) + 1;
    loadImgPokemons(randomPoke, index, images);
  }
}

function loadImgPokemons(idPokemon, posImg, images) {
  fetch(urlBase + idPokemon)
    .then((response) => response.json())
    .then((data) => {
      let imageSources = data.sprites.front_default;
      let pokeName = data.name;
      images[posImg].src = imageSources;
      images[posImg].alt = pokeName;
      if ("img-" + (posImg + 1) == localStorage.getItem("guessWinner")) {
        localStorage.setItem("type", data.types[0].type.name);
        localStorage.setItem("namePokemon", pokeName);
        localStorage.setItem("idPokemon", data.id);
        localStorage.setItem("posPokemon", posImg + 1);
      }
    });
}

function initHint() {
  const divHint1 = document.getElementById("div-hint1");
  const divHint2 = document.getElementById("div-hint2");
  divHint1.innerHTML = `<h1>El numero esta en un lugar donde el pokemon es de tipo: <br><span id="text-hint1">Se desbloqueará cuando tu puntuación sea ${firstHint} o menor</span></h1>`;
  divHint2.innerHTML = `<h1>La mitad es ${
    cantBox / 2
  } ¿El numero esta por encima o por debajo?: <br> <span id="text-hint2"> Se desbloqueará cuando tu puntuación sea ${secondHint}</span></h1>`;
}

function setHintImg(type, pokeUrl) {
  if (score === firstHint) {
    for (let key in pokeUrl) {
      if (key == type) {
        var img = document.createElement("img");
        img.src = "../assets/img/iconosTiposElementales/" + key + ".png";
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
  if (score === secondHint) {
    var hintText = document.querySelector("#text-hint2");
    let posHint = parseInt(localStorage.getItem("posPokemon"));
    let hint;
    if (maxScore / 2 > posHint) {
      hint = "El numero es mayor a " + cantBox / 2;
    } else {
      hint = "El numero es menor a " + cantBox / 2;
    }
    hintText.textContent = hint;
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
  msgDiv.textContent = "Numero incorrecto, inténtalo de nuevo.";
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

function removeBox() {
  for (let index = 0; index < cantBox; index++) {
    boxId = "box-"+index;
    const boxToRemove = document.getElementById(boxId);
    if (boxToRemove) {
      boxToRemove.parentNode.removeChild(boxToRemove);
    }
  } 
}