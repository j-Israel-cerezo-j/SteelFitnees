function keydown() {
    
}
const inputField = document.getElementById("exampleDataList");

inputField.addEventListener("keydown", function (event) {
    if (event.key === "Enter") {
        event.preventDefault(); // Prevenir el comportamiento por defecto del botón enviar
        var formData = new FormData(document.getElementById("formOnkeyupMaster"));
        var url = "Handlers/OnkeyupSearchController.aspx?catalogo=actionSearchubmit&action=actionSearchubmit";
        OnkeyupSerchCatalogos(formData, url)
    }
});