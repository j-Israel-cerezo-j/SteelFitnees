function buildDaysSlc(json) {
    if (document.getElementById("days") != undefined) {
        var slcDays = document.getElementById("days");
        document.getElementById("days").innerHTML = "";
        var optionSelection = document.createElement("option");
        optionSelection.value = "";
        optionSelection.text = "Seleccione una opción";
        slcDays.appendChild(optionSelection);
        for (var i = 0; i < json.length; i++) {
            var option = document.createElement("option")
            option.value = json[i].id;
            option.text = json[i].dia;
            slcDays.appendChild(option);
        }
    }
}