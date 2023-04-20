function onkeyupSearchh() {
    var id = document.getElementById("branches").value
    var formData = new FormData(document.getElementById("formOnkeyup"));
    var url = "Handlers/OnkeyupSearchController.aspx?catalogo=productsByBrancheAndCharacteres&action=productosByBranche&id=" + id;
    OnkeyupSerchCatalogos(formData, url)
}