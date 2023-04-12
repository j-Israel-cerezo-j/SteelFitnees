function onkeyupSearchh() {
    var formData = new FormData(document.getElementById("formOnkeyup"));
    var url = "Handlers/OnkeyupSearchController.aspx?catalogo=allProducts&action=allProducts";
    OnkeyupSerchCatalogos(formData, url)
}