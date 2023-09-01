function mostrarCarga() {
    var rueda = document.querySelector(".rueda");
    var cargando = document.querySelector(".cargando");
    rueda.style.display = "block";
    cargando.style.display = "block";
}


function ocultarCarga() {
	var rueda = document.querySelector(".rueda");
	var cargando = document.querySelector(".cargando");
	rueda.style.display = "none";
	cargando.style.display = "none";
}