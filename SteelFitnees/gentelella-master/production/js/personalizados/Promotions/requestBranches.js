function requestBranches() {
    return new Promise((resolve,reject) => {
        request(json => {
            var htmlSlcBranche = `<option value="-1" selected>Solo página de inicio</option>`;
            json.forEach(item => {
                htmlSlcBranche += `<option value="${item.id}">${item.Nombre}</option>`
            });
            resolve(htmlSlcBranche);
        }, 'Handlers/sucursalesController.aspx', false);
    });    
}


function requestBranchesSlcFilter() {
    request(json => {
        if (document.getElementById("filter") != undefined) {
            var slcBranches = document.getElementById("filter");
            document.getElementById("filter").innerHTML = "";
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
            var optionSelection = document.createElement("option");
            optionSelection.value = "-2";
            optionSelection.text = "Promociones sin sucursal";
            slcBranches.onchange = requestPromotionsByFilterBranchAndVisibilityOrNone

            slcBranches.appendChild(optionSelection);
        }
    }, 'Handlers/sucursalesController.aspx', false);
}


