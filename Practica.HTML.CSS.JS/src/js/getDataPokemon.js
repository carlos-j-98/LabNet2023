export function loadImgPokemons(idPokemon, posImg)
{
    fetch('https://pokeapi.co/api/v2/pokemon/'+idPokemon)
        .then(response => response.json())
        .then(data => {
            
            let imageSources = data.sprites.front_default;
            const images = document.querySelectorAll("img");
            images[posImg].src = imageSources;
            document.body.appendChild(imageElement);
        })
        .catch(error => {
        });
}
