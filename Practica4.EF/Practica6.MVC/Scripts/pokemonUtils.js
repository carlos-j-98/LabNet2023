const frontImgs = document.querySelectorAll('.img-front');
const backImgs = document.querySelectorAll('.img-back');
let currentIndex = 0;

const btnBack = document.getElementById("btn-back");
const btnNext = document.getElementById("btn-next");
const limiteSuperior = 1000;
const urlParams = new URLSearchParams(window.location.search);
let offset = Number(urlParams.get("offset"));

setInterval(ChangeFrontToBack, 6000);

function ChangeFrontToBack() {
    for (let i = 0; i < frontImgs.length; i++) {
        frontImgs[i].classList.add('d-none');
        backImgs[i].classList.remove('d-none');
    }
    setTimeout(function () {
        ChangeBackToFront();
    },3000)
}
function ChangeBackToFront() {
    for (let i = 0; i < frontImgs.length; i++) {
        frontImgs[i].classList.remove('d-none');
        backImgs[i].classList.add('d-none');
    }
}

if (offset >= limiteSuperior) {
    btnNext.style.display = "none";
} else {
    btnNext.style.display = "block";
}

const limiteInferior = 0;
if (offset === limiteInferior) {
    btnBack.style.display = "none";
} else {
    btnBack.style.display = "block";
}

btnBack.addEventListener("click", () => {
    offset -= 10;
    const url = new URL(window.location.href);
    url.searchParams.set("offset", offset);
    window.location.href = url.toString();
});
btnNext.addEventListener("click", () => {
    offset += 10;
    const url = new URL(window.location.href);
    url.searchParams.set("offset", offset);
    window.location.href = url.toString();
});