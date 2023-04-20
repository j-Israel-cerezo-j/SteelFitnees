function onkeyupSearchhMaster() {        
    var formData = new FormData(document.getElementById("formOnkeyupMaster"));
    var url = "Handlers/OnkeyupSearchController.aspx?catalogo=searchMaster&action=searchMaster";
    OnkeyupSerchCatalogos(formData, url)
}