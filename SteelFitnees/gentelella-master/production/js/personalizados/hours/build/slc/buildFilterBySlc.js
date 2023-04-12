function buildFilterBySlc(json) {
    if (document.getElementById("filterTableBy") != undefined) {
        var slcDays = document.getElementById("filterTableBy");
        document.getElementById("filterTableBy").innerHTML = "";
        var optionSelection = document.createElement("option");
        optionSelection.value = "";
        optionSelection.text = "Seleccione una opción";
        slcDays.appendChild(optionSelection);
        for (var i = 0; i < json.length; i++) {
            var option = document.createElement("option")
            option.value = json[i].id;
            if (json[i].Nombre == undefined) {
                option.text = json[i].dia;
            } else {
                option.text = json[i].Nombre;
            }
            slcDays.appendChild(option);
        }
    }
}