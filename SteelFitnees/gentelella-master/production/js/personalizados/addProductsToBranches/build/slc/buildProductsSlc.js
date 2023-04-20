function buildProductsSlc(json) {
    if (document.getElementById("products") != undefined) {
        var slcProducts = document.getElementById("products");
        document.getElementById("products").innerHTML = "";
        var optionSelection = document.createElement("option");
        optionSelection.value = "";
        optionSelection.text = "Seleccione una opción";
        slcProducts.appendChild(optionSelection);
        for (var i = 0; i < json.length; i++) {
            var option = document.createElement("option")
            option.value = json[i].id;
            option.text = json[i].Nombre;
            slcProducts.appendChild(option);
        }
    }
}