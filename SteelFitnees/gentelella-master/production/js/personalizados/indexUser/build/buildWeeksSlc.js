function buildWeeks() {
    const selectSemanas = document.getElementById('weeks');
    
    document.getElementById("weeks").innerHTML = "";
    var optionSelection = document.createElement("option");
    optionSelection.value = "-1";
    optionSelection.text = "Seleccione una opción";
    selectSemanas.appendChild(optionSelection);

    // Creamos un objeto Date con la fecha actual
    const fechaActual = new Date();

    // Creamos un objeto Date con la fecha del primer día del año actual
    const primerDiaDelAnioActual = new Date(fechaActual.getFullYear(), 0, 1);

    // Obtenemos el número de milisegundos desde el 1 de enero de 1970 para el primer día del año actual
    const tiempoPrimerDiaDelAnioActual = primerDiaDelAnioActual.getTime();

    for (let i = 0; i < 52; i++) {
        // Calculamos el tiempo en milisegundos para la semana actual
        const tiempoSemanaActual = tiempoPrimerDiaDelAnioActual + (i * 7 * 24 * 60 * 60 * 1000);

        // Creamos un objeto Date con la fecha de la semana actual
        const fechaSemanaActual = new Date(tiempoSemanaActual);

        // Obtenemos el número de la semana actual
        const semanaActual = i + 1;

        // Creamos una opción para el select con la semana actual
        const opcion = document.createElement('option');
        opcion.value = fechaSemanaActual.toLocaleDateString();
        opcion.text = `Semana ${semanaActual} - ${fechaSemanaActual.toLocaleDateString()}`;

        // Agregamos la opción al select
        selectSemanas.appendChild(opcion);
    }
}