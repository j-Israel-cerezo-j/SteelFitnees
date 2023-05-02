
function mousemoveZoomImage(idContenedor,idImagen) {
    const imagenContenedor = document.getElementById(idContenedor);
    const imagen = document.getElementById(idImagen);

    imagenContenedor.addEventListener("mousemove", (event) => {
        const mouseX = event.clientX - imagenContenedor.offsetLeft;
        const mouseY = event.clientY - imagenContenedor.offsetTop;

        const offsetX = (mouseX / imagenContenedor.clientWidth) * 60;
        const offsetY = (mouseY / imagenContenedor.clientHeight) * 60;

        imagen.style.transform = `scale(2) translate(-${offsetX}%, -${offsetY}%)`;
    });

   
}

function mouseleaveZoomImage(idContenedor, idImagen) {
    const imagenContenedor = document.getElementById(idContenedor);
    const imagen = document.getElementById(idImagen);

    imagenContenedor.addEventListener("mouseleave", () => {
        imagen.style.transform = "scale(1) translate(0, 0)";
    });
}

