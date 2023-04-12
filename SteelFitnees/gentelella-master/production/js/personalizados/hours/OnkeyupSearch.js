function onkeyupSearchh() {
    var formData = new FormData(document.getElementById("formOnkeyup"));
    var url = "Handlers/OnkeyupSearchController.aspx?catalogo=horas&action=full";
    OnkeyupSerchCatalogos(formData, url)
}