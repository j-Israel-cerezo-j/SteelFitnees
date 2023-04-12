function onkeyupSearchh() {
    var formData = new FormData(document.getElementById("formOnkeyup"));
    var url = "Handlers/OnkeyupSearchController.aspx?catalogo=dias&action=full";
    OnkeyupSerchCatalogos(formData, url)
}