function onkeyupSearchh() {
    var selectBranches = document.getElementById("branches")
    var branchesvalue = selectBranches.value
    var formData = new FormData(document.getElementById("formOnkeyup"));

    var url ="Handlers/OnkeyupSearchController.aspx?catalogo=commentsCharacteres&action=comments&id="+branchesvalue;
    OnkeyupSerchCatalogos(formData, url)
}