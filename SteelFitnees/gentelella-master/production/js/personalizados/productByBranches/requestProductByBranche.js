function buildProductsByBranche() {
    var select = document.getElementById("branches")
    var value = select.value
    var text = select.options[select.selectedIndex].innerText; //El texto de la opción seleccionada
    request(buildProductById, 'Handlers/productsController.aspx?action=getby&id=' + value);
    if (value != -1) {
        document.getElementById("nameBranche").innerHTML = text;
    }    
}