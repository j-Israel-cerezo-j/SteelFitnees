function buildPromotions(json) {
    var html = "";
    json.forEach(item => {
        html += `  <div class="slide2">
                <img src="${item.img}" height="300" width="300" alt="" />
            </div>`
    });
    document.getElementById("containerPromotions").innerHTML = html;

    const slideContainer = document.getElementById('containerPromotions');
    const slides = slideContainer.getElementsByClassName('slide2');
    const slideCount = slides.length;

    // Duplica los slides dentro del contenedor
    for (let i = 0; i < slideCount; i++) {
        slideContainer.appendChild(slides[i].cloneNode(true));
    }

    // Inicia la animación después de un pequeño retraso
    setTimeout(() => {
        slideContainer.style.animationDuration = `${slideCount * 20}s`; // Ajusta la duración según tus necesidades
    }, 100);
}



