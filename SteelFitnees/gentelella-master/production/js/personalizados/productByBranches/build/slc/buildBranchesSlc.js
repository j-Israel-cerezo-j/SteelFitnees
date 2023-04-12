function buildBranchesSlc(json) {
    if (document.getElementById("branches") != undefined) {
        var slcBranches = document.getElementById("branches");
        document.getElementById("branches").innerHTML = "";
        var optionSelection = document.createElement("option");
        optionSelection.value = "-1";
        optionSelection.text = "Seleccione una opción";
        slcBranches.appendChild(optionSelection);
        for (var i = 0; i < json.length; i++) {
            var option = document.createElement("option")
            option.value = json[i].id;
            option.text = json[i].Nombre;
            slcBranches.appendChild(option);
        }
    }
}