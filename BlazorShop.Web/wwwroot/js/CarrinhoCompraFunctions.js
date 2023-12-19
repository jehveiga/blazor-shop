function tornaBotaoAtualizarQuantidadeVisivel(id, visible) {
    const atualizaQuantidadeButton = document.querySelector("button[data-itemId='" + id + "']");

    if (visible) {
        atualizaQuantidadeButton.style.display = "inline-block";
    }
    else {
        atualizaQuantidadeButton.style.display = "none";
    }

}