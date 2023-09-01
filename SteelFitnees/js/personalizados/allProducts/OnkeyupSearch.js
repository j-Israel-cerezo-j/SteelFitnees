function onkeyupSearchh() {
    var formData = new FormData(document.getElementById("formOnkeyup"));
    var url = "Handlers/OnkeyupSearchController.aspx?catalogo=allProducts&action=allProducts";
    OnkeyupSerchCatalogos(formData, url)
}
function onMin() {
    var valueMin = document.getElementById("min").value;
    var valueMax = document.getElementById("max").value;
    request(buildAllProduct, 'Handlers/filterByController.aspx?valueMin=' + valueMin + '&valueMax=' + valueMax + '&action=prices&filterBy=prices');
}
function onMax() {
    var valueMin = document.getElementById("min").value;
    var valueMax = document.getElementById("max").value;
    request(buildAllProduct, 'Handlers/filterByController.aspx?valueMin=' + valueMin + '&valueMax=' + valueMax + '&action=prices&filterBy=prices');
}