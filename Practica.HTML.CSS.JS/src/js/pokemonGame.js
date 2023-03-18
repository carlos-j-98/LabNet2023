import { loadImgPokemons } from "./getDataPokemon.js";

const images = document.querySelectorAll('img');
const randomNumber = Math.floor(Math.random() * 6);
images.forEach((image) => {
  image.addEventListener('click', () => {
    const clickedNumber = parseInt(image.getAttribute('id'));

    if (clickedNumber === randomNumber) {
      alert('¡Correcto! ¡Ganaste!');
    } else {
      alert('Incorrecto. Intenta de nuevo.');
    }
  });
});

function resetGame() {
  location.reload();
}

function initImg(){
    for (let index = 0; index < 6; index++) {
        const randomPoke = Math.floor(Math.random() * 898) + 1;
        loadImgPokemons(randomPoke,index);
    }
}
initImg();
