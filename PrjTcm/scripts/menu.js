function alternarMenu() {
    const menuLateral = document.getElementById("menu-lateral");
    menuLateral.classList.toggle("ativo");
}

document.addEventListener("click", function (event) {
    const menuLateral = document.getElementById("menu-lateral");
    const botaoMenu = document.querySelector(".botao-menu");

    if (menuLateral.classList.contains("ativo") &&
        !menuLateral.contains(event.target) &&
        !botaoMenu.contains(event.target)) {
        menuLateral.classList.remove("ativo");
    }
});